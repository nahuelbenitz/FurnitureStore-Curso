using Blazor.FurnitureStore.Repositories.Interfaces;
using Blazor.FurnitureStore.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Transactions;

namespace Blazor.FurnitureStore.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IOrderProductRepository _orderProductRepository;

        public OrderController(IOrderRepository orderRepository, IOrderProductRepository orderProductRepository)
        {
            _orderRepository = orderRepository;
            _orderProductRepository = orderProductRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Order>> GetOrders()
        {
            var orders = await _orderRepository.GetAllOrders();
            foreach (var items in orders) 
            {
                items.Products = (List<Product>)await _orderProductRepository.GetByOrder(items.Id);
            }

            return orders;
        }

        [HttpGet("{id}")]
        public async Task<Order> GetById(int id)
        {
            var order = await _orderRepository.GetDetails(id);

            var products = await _orderProductRepository.GetByOrder(id);

            if (order is not null)
                order.Products = products.ToList();

            return order;
        }

        [HttpGet("GetNextNumber")]
        public async Task<int> GetNextNumber()
        {
            return await _orderRepository.GetNextNumber();
        }

        [HttpPost]
        public async Task<IActionResult> AddOrder([FromBody] Order order)
        {
            if (order is null)
                return BadRequest();

            if (order.OrderNumber == 0)
                ModelState.AddModelError("OrderNumber", "Order Number no puede ser 0");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            using (TransactionScope scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                order.Id = await _orderRepository.GetNextId();

                await _orderRepository.InsertOrder(order);

                if (order.Products is not null && order.Products.Any())
                {
                    foreach (var produc in order.Products)
                    {
                        await _orderProductRepository.InsertOrderProduct(order.Id, produc);
                    }
                }
                scope.Complete();

            }


            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _orderRepository.DeleteOrder(id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrder(int id, [FromBody] Order order)
        {
            if (order is null)
                return BadRequest();

            if (order.OrderNumber == 0)
                ModelState.AddModelError("OrderNumber", "Order Number no puede ser 0");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            using (TransactionScope scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {

                await _orderRepository.UpdateOrder(order);
                await _orderProductRepository.DeleteOrderProductByOrder(order.Id);

                if (order.Products is not null && order.Products.Any())
                {
                    foreach (var produc in order.Products)
                    {
                        await _orderProductRepository.InsertOrderProduct(order.Id, produc);
                    }
                }
                scope.Complete();

            }


            return NoContent();
        }
    }
}
