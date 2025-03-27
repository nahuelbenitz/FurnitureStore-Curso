using Blazor.FurnitureStore.Repositories.Interfaces;
using Blazor.FurnitureStore.Shared;
using Dapper;
using System.Data;

namespace Blazor.FurnitureStore.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly IDbConnection _connection;

        public OrderRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public async Task<int> GetNextNumber()
        {
            var sql = @$" SELECT MAX(OrderNumber) + 1
                          FROM Orders ";

            return await _connection.QueryFirstAsync<int>(sql, new { });
        }

        public async Task<bool> InsertOrder(Order order)
        {
            var sql = @$"
                         INSERT INTO Orders ( OrderNumber, ClientId, OrderDate, DeliveryDate, Total)
                         VALUES (@OrderNumber, @ClientId, @OrderDate, @DeliveryDate, @Total)
                         ";

            var result = await _connection.ExecuteAsync(sql,
                new
                {
                    order.OrderNumber,
                    order.ClientId,
                    order.OrderDate,
                    order.DeliveryDate,
                    order.Total
                });

            return result > 0;
        }
    }
}
