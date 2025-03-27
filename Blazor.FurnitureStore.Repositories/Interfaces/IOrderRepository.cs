using Blazor.FurnitureStore.Shared;

namespace Blazor.FurnitureStore.Repositories.Interfaces
{
    public interface IOrderRepository
    {
        Task<bool> InsertOrder(Order order);
        Task<bool> UpdateOrder(Order order);
        Task DeleteOrder(int id);
        Task<int> GetNextNumber();
        Task<int> GetNextId();
        Task<IEnumerable<Order>> GetAllOrders();
        Task<Order> GetDetails(int id);
    }
}
