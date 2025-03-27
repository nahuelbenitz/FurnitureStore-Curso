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

        public async Task<IEnumerable<Order>> GetAllOrders()
        {

            var sql = @$" SELECT o.[Id], [OrderNumber], [ClientId], [OrderDate], [DeliveryDate], [Total], c.LastName + ', ' + c.FirstName as ClientName
                          FROM Orders o
                          INNER JOIN Clients c on o.ClientId = c.Id ";

            return await _connection.QueryAsync<Order>(sql, new { });
        }

        public async Task<Order> GetDetails(int id)
        {

            var sql = @$" SELECT [Id], [OrderNumber], [ClientId], [OrderDate], [DeliveryDate], [Total]
                          FROM Orders 
                          WHERE Id = @Id";

            return await _connection.QueryFirstOrDefaultAsync<Order>(sql, new { Id = id });
        }

        public async Task<int> GetNextId()
        {
            var sql = @$" SELECT MAX(OrderNumber) + 1
                          FROM Orders ";

            return await _connection.QueryFirstAsync<int>(sql, new { });
        }

        public async Task<int> GetNextNumber()
        {
            var sql = @$" SELECT MAX(OrderNumber) + 1
                          FROM Orders ";

            var number = await _connection.QueryFirstAsync<int?>(sql, new { });

            if (number is null)
                number = 1;

            return (int)number;
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

        public async Task<bool> UpdateOrder(Order order)
        {
            var sql = @$"
                         UPDATE Orders SET ClientId = @ClientId, OrderDate = @OrderDate, DeliveryDate = @DeliveryDate
                         WHERE Id = @Id";

            var result = await _connection.ExecuteAsync(sql,
                new
                {
                    order.ClientId,
                    order.OrderDate,
                    order.DeliveryDate,
                    order.Id
                });

            return result > 0;
        }

        public async Task DeleteOrder(int id)
        {
            var sql = $"DELETE FROM Orders WHERE Id = @Id";

            await _connection.ExecuteAsync(sql,new { Id = id });
        }
    }
}
