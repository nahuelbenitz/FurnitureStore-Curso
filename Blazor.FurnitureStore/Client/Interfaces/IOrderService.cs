using Blazor.FurnitureStore.Shared;

namespace Blazor.FurnitureStore.Client.Interfaces
{
    public interface IOrderService
    {
        Task Save(Order order);
        Task<int> GetNextNumber();
    }
}
