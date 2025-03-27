using Blazor.FurnitureStore.Repositories.Interfaces;
using Blazor.FurnitureStore.Shared;
using Dapper;
using System.Data;

namespace Blazor.FurnitureStore.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly IDbConnection _connection;

        public ClientRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public async Task<IEnumerable<Client>> GetClients()
        {
            var sql = @$"SELECT [Id], [FirstName], [LastName], [BirthDate], [Phone], [Address]
                         FROM Clients";

            return await _connection.QueryAsync<Client>(sql, new { });
        }
    }
}
