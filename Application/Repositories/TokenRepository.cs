using Application.DTO;
using Application.Interfaces.Token;
using Dapper;
using Domain.Models;
using Infrastructure.DbConnection;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repositories
{
    public class TokenRepository : ITokenRepository
    {
        private readonly IDbConnectionFactory _connectionFactory;

        public TokenRepository(IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }
        public async Task<Cliente> GetJWTClient(string cpf)
        {
            using var connection = await _connectionFactory.CreateConnectionAsync(DatabaseConnectionName.DB_FIAP_STORE);
            var query = "SELECT * FROM Cliente WHERE Cliente.CPF = @CPF";
            return connection.Query<Cliente>(query,  new { CPF = cpf } ).FirstOrDefault();            
        }
    }
}
