using System.Data;

namespace fiap_store.Infraestructure
{
    public interface IDbConnectionFactory
    {
        public Task<IDbConnection> CreateConnectionAsync(DatabaseConnectionName connectionName);
    }
}
