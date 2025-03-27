using Blazor.FurnitureStore.Repositories.Interfaces;
using Blazor.FurnitureStore.Shared;
using Dapper;
using System.Data;

namespace Blazor.FurnitureStore.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly IDbConnection _dbConnection;

        public ProductRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public Task<IEnumerable<Product>> GetByCategory(int productCategoryId)
        {
            var sql = @$"SELECT Id, Name, Price, CategoryId as ProductCAtegoryId
                         FROM Products
                         WHERE CategoryId = @Id ";

            return _dbConnection.QueryAsync<Product>(sql, new { Id = productCategoryId });
        }

        public Task<Product> GetDetails(int productId)
        {
            var sql = @$"SELECT Id, Name, Price, CategoryId as ProductCAtegoryId
                         FROM Products
                         WHERE Id = @Id ";

            return _dbConnection.QueryFirstOrDefaultAsync<Product>(sql, new { Id = productId });
        }
    }
}
