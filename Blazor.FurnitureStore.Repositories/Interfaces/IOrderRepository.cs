using Blazor.FurnitureStore.Shared;

namespace Blazor.FurnitureStore.Repositories.Interfaces
{
    public interface IOrderRepository
    {
        Task<bool> InsertOrder(Order order);
        Task<int> GetNextNumber();
    }
}
