using Blazor.FurnitureStore.Repositories.Interfaces;
using Blazor.FurnitureStore.Shared;
using Dapper;
using System.Data;

namespace Blazor.FurnitureStore.Repositories
{
    public class ProductCategoryRepository : IProductCategoryRepository
    {
        private readonly IDbConnection _dbConnection;

        public ProductCategoryRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<IEnumerable<ProductCategory>> GetAll()
        {
            var sql = @$" SELECT Id AS Id, Name AS Name 
                          FROM ProductCategories ";

            return await _dbConnection.QueryAsync<ProductCategory>(sql, new { });
        }
    }
}
