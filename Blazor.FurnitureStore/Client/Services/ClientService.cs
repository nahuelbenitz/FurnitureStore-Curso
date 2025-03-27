using Blazor.FurnitureStore.Client.Interfaces;
using System.Net.Http.Json;

namespace Blazor.FurnitureStore.Client.Services
{
    public class ClientService : IClientService
    {
        private readonly HttpClient _httpClient;

        public ClientService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<FurnitureStore.Shared.Client>> GetClients()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<Blazor.FurnitureStore.Shared.Client>>("api/client");
        }
    }
}
