using Blazor.FurnitureStore.Shared;

namespace Blazor.FurnitureStore.Client.Interfaces
{
    public interface IClientService
    {
        Task<IEnumerable<Blazor.FurnitureStore.Shared.Client>> GetClients();
    }
}
