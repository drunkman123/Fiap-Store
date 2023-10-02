using Dapper;
using Infrastructure.DbConnection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Logging
{
    public class LogErrorRepository
    {
        private readonly IDbConnectionFactory _connectionFactory;

        public LogErrorRepository(IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<string> LogError(LogErro logErro)
        {
            using var connection = await _connectionFactory.CreateConnectionAsync(DatabaseConnectionName.DB_FIAP_STORE);
            using var transaction = connection.BeginTransaction();

            try
            {
                string insertLogErro = @"
            INSERT INTO dbo.LogErro (IdLog, Message, StackTrace, TimeStamp) 
            VALUES (@IdLog, @Message, @StackTrace, @TimeStamp);";

                connection.Execute(insertLogErro, logErro, transaction);

                transaction.Commit();
                return logErro.IdLog;
            }
            catch (Exception)
            {
                transaction.Rollback();
                throw;
            }
        }
    }
}
