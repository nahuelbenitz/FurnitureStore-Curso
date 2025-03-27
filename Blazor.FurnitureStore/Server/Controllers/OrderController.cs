using Blazor.FurnitureStore.Repositories.Interfaces;
using Blazor.FurnitureStore.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Blazor.FurnitureStore.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;

        public OrderController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
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

            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            await _orderRepository.InsertOrder(order);

            return NoContent();
        }
    }
}
