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

        public async Task<int> GetNextNumber()
        {
            return await _httpClient.GetFromJsonAsync<int>("api/order/GetNextNumber");
        }

        public async Task Save(Order order)
        {
            if (order.Id == 0)
                await _httpClient.PostAsJsonAsync<Order>("api/order", order);
        }
    }
}
