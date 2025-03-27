using Blazor.FurnitureStore.Shared;

namespace Blazor.FurnitureStore.Repositories.Interfaces
{
    public interface IClientRepository
    {
        Task<IEnumerable<Client>> GetClients();
    }
}
