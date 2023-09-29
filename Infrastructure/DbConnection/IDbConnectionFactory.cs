using System.Data;

namespace Infrastructure.DbConnection
{
    public interface IDbConnectionFactory
    {
        public Task<IDbConnection> CreateConnectionAsync(DatabaseConnectionName connectionName);
    }
}
