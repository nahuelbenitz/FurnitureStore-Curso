using Blazor.FurnitureStore.Client.Interfaces;
using Blazor.FurnitureStore.Shared;
using System.Net.Http.Json;

namespace Blazor.FurnitureStore.Client.Services
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _httpClient;

        public ProductService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<Product>> GetByCategory(int productCategoryId)
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<Product>>($"api/product/GetByCategory/{productCategoryId}");
        }

        public async Task<Product> GetDetails(int productId)
        {
            return await _httpClient.GetFromJsonAsync<Product>($"api/product/{productId}");
        }
    }
}
