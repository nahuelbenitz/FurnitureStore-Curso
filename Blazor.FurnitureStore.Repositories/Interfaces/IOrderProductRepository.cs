using Blazor.FurnitureStore.Shared;

namespace Blazor.FurnitureStore.Repositories.Interfaces
{
    public interface IOrderProductRepository
    {
        Task<bool> InsertOrderProduct(int orderId, Product product);
        Task<IEnumerable<Product>> GetByOrder(int orderId);
        Task<bool> DeleteOrderProductByOrder(int orderId);
    }
}
