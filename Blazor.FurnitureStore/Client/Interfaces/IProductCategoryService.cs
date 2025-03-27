using Blazor.FurnitureStore.Shared;

namespace Blazor.FurnitureStore.Client.Interfaces
{
    public interface IProductCategoryService
    {
        Task<IEnumerable<ProductCategory>> GetProductCategories();
    }
}
