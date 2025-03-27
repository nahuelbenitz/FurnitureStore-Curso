using Blazor.FurnitureStore.Shared;

namespace Blazor.FurnitureStore.Client.Interfaces
{
    public interface IOrderService
    {
        Task Save(Order order);
        Task<int> GetNextNumber();
        Task<IEnumerable<Order>> GetAllOrders();
        Task<Order> GetDetails(int id);
        Task DeleteOrder(int id);
    }
}
