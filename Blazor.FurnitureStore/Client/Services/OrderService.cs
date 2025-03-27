using Blazor.FurnitureStore.Client.Interfaces;
using Blazor.FurnitureStore.Shared;
using System.Net.Http.Json;

namespace Blazor.FurnitureStore.Client.Services
{
    public class OrderService : IOrderService
    {
        private readonly HttpClient _httpClient;

        public OrderService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task DeleteOrder(int id)
        {
            await _httpClient.DeleteAsync($"api/order/{id}");
        }

        public async Task<IEnumerable<Order>> GetAllOrders()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<Order>>("api/order");
        }

        public async Task<Order> GetDetails(int id)
        {
            return await _httpClient.GetFromJsonAsync<Order>($"api/order/{id}");
        }

        public async Task<int> GetNextNumber()
        {
            return await _httpClient.GetFromJsonAsync<int>("api/order/GetNextNumber");
        }

        public async Task Save(Order order)
        {
            if (order.Id == 0)
                await _httpClient.PostAsJsonAsync<Order>("api/order", order);
            else
                await _httpClient.PutAsJsonAsync<Order>($"api/order/{order.Id}", order);
        }
    }
}
