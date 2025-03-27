using Blazor.FurnitureStore.Shared;

namespace Blazor.FurnitureStore.Client.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetByCategory(int productCategoryId);
        Task<Product> GetDetails(int productId);
    }
}
