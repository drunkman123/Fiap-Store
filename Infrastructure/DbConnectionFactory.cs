using System.Data;
using System.Data.SqlClient;

namespace fiap_store.Infraestructure
{
    public class DbConnectionFactory : IDbConnectionFactory
    {
        private readonly IDictionary<DatabaseConnectionName, string> _connectionDict;


        public DbConnectionFactory(IDictionary<DatabaseConnectionName, string> connectionDict)
        {
            _connectionDict = connectionDict;
        }
        public async Task<IDbConnection> CreateConnectionAsync(DatabaseConnectionName connectionName)
        {
            string connectionString = null;
            _connectionDict.TryGetValue(connectionName, out connectionString);
            var connection = new SqlConnection(connectionString);

            if (connection.State != ConnectionState.Open)
            {
                await connection.OpenAsync();
            }

            return connection;

        }
    }
}