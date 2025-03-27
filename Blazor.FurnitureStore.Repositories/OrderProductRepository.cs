using Blazor.FurnitureStore.Repositories.Interfaces;
using Blazor.FurnitureStore.Shared;
using Dapper;
using System.Data;

namespace Blazor.FurnitureStore.Repositories
{
    public class OrderProductRepository : IOrderProductRepository
    {
        private readonly IDbConnection _connection;

        public OrderProductRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public async Task<bool> DeleteOrderProductByOrder(int orderId)
        {
            var sql = @$"DELETE FROM OrderProducts
                        WHERE OrderId = @Id";

            var result = await _connection.ExecuteAsync(sql, new { Id = orderId });
            return result > 0;
        }

        public async Task<IEnumerable<Product>> GetByOrder(int orderId)
        {
            var sql = @$"SELECT Id, Name, Price, CategoryId as ProductCategoryId, Quantity
                         FROM OrderProducts
                            Inner Join Products p on p.Id = ProductId
                         WHERE OrderId = @Id";

            return await _connection.QueryFirstAsync(sql, new { Id = orderId });
        }

        public async Task<bool> InsertOrderProduct(int orderId, Product product)
        {
            var sql = @$"INSERT INTO OrderProducts (OrderId, ProductId, Quantity)
                         VALUES (@OrderId, @ProductId, @Quantity)";

            var result = await _connection.ExecuteAsync(sql,
                new
                {
                    OrderId = orderId,
                    ProductId = product.Id,
                    product.Quantity
                });

            return result > 0;
        }
    }
}
