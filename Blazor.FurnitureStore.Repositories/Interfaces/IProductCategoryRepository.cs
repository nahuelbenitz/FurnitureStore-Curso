using Blazor.FurnitureStore.Shared;

namespace Blazor.FurnitureStore.Repositories.Interfaces
{
    public interface IProductCategoryRepository
    {
        Task<IEnumerable<ProductCategory>> GetAll();
    }
}
