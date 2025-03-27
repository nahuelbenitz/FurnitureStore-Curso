using Blazor.FurnitureStore.Shared;

namespace Blazor.FurnitureStore.Repositories.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetByCategory(int productCategoryId);
        Task<Product> GetDetails(int productId);
    }
}
