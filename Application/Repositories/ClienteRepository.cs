using Application.Interfaces;
using Dapper;
using Domain.Models;
using Infrastructure.DbConnection;

namespace Application.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly IDbConnectionFactory _connectionFactory;

        public ClienteRepository(IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<bool> AdicionarEndereco(int clienteId, Endereco endereco)
        {
            using var connection = await _connectionFactory.CreateConnectionAsync(DatabaseConnectionName.DB_FIAP_STORE);

            string insertEnderecoQuery = @"
            INSERT INTO Endereco (IdCliente, Rua, Bairro, Cidade, Numero, Complemento, CEP) 
            VALUES (@IdCliente, @Rua, @Bairro, @Cidade, @Numero, @Complemento, @CEP);";

            endereco.IdCliente= clienteId;
            connection.Execute(insertEnderecoQuery, endereco);

            return true;

        }

        public async void Alterar(Cliente entidade)
        {
            using var connection = await _connectionFactory.CreateConnectionAsync(DatabaseConnectionName.DB_FIAP_STORE);
            using var transaction = connection.BeginTransaction();

            try
            {
                string putClienteQuery = @"
                                        UPDATE Cliente
                                        SET Email = @Email, Password = @Password, Telefone = @Telefone
                                        WHERE IdCliente = @IdCliente;";

                int clienteId = connection.Execute(putClienteQuery, entidade, transaction);

                transaction.Commit();

            }
            catch (Exception)
            {
                transaction.Rollback();
                throw;
            }
        }

        public async Task<int> Cadastrar(Cliente entidade)
        {
            using var connection = await _connectionFactory.CreateConnectionAsync(DatabaseConnectionName.DB_FIAP_STORE);
            using var transaction = connection.BeginTransaction();

            try
            {
                string insertClienteQuery = @"
            INSERT INTO dbo.Cliente (Nome, CPF, Telefone, Email, Password, IdPermissao, DataNascimento) 
            OUTPUT INSERTED.[IdCliente]
            VALUES (@Nome, @CPF, @Telefone, @Email, @Password, @IdPermissao, @DataNascimento);";

                int clienteId = connection.QuerySingle<int>(insertClienteQuery, entidade, transaction);

                string insertEnderecoQuery = @"
            INSERT INTO Endereco (IdCliente, Rua, Bairro, Cidade, Numero, Complemento, CEP) 
            VALUES (@IdCliente, @Rua, @Bairro, @Cidade, @Numero, @Complemento, @CEP);";

                entidade.Endereco.ElementAt(0).IdCliente = clienteId;
                connection.Execute(insertEnderecoQuery, entidade.Endereco, transaction);

                transaction.Commit();

                return clienteId;
            }
            catch (Exception)
            {
                transaction.Rollback();
                throw;
            }

        }
        public void Deletar(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> ExistsClient(string cpf)
        {
            using var connection = await _connectionFactory.CreateConnectionAsync(DatabaseConnectionName.DB_FIAP_STORE);
            var query = "SELECT COUNT(*) FROM Cliente WHERE CPF = @CPF";
            int count = connection.ExecuteScalar<int>(query, new { CPF = cpf });
            return count > 0;
        }

        public async Task<Cliente> GetById(int idCliente)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Cliente>> ObterTodos()
        {
            using var connection = await _connectionFactory.CreateConnectionAsync(DatabaseConnectionName.DB_FIAP_STORE);
            string selectQuery = @"
                                    SELECT
                                        c.IdCliente,
                                        c.Nome,
                                        c.CPF,
                                        c.Telefone,
                                        c.Email,
                                        c.IdPermissao,
                                        c.DataNascimento,
                                        e.IdEndereco,
                                        e.Rua,
                                        e.Numero,
                                        e.Bairro,
                                        e.Cidade,
                                        e.Complemento,
                                        e.CEP
                                    FROM dbo.Cliente c
                                    LEFT JOIN Endereco e ON c.IdCliente = e.IdCliente;";

            var ClienteDictionary = new Dictionary<int, Cliente>();

            var results = connection.Query<Cliente, Endereco, Cliente>(
                    selectQuery,
                    (c, e) =>
                    {
                        if (!ClienteDictionary.TryGetValue(c.IdCliente, out var cliente))
                        {
                            cliente = c;
                            cliente.Endereco = new List<Endereco>();
                            ClienteDictionary.Add(c.IdCliente, cliente);
                        }

                        if (e != null)
                        {
                            cliente.Endereco.Add(e);
                        }

                        return cliente;
                    },
                    splitOn: "IdEndereco");

            return ClienteDictionary.Values;
        }
        public async Task<Cliente> Get(int idCliente)
        {
            using var connection = await _connectionFactory.CreateConnectionAsync(DatabaseConnectionName.DB_FIAP_STORE);
            string selectQuery = @"
                                    SELECT
                                        c.IdCliente,
                                        c.Nome,
                                        c.CPF,
                                        c.Telefone,
                                        c.Email,
                                        c.IdPermissao,
                                        c.DataNascimento,
                                        e.IdEndereco,
                                        e.Rua,
                                        e.Numero,
                                        e.Bairro,
                                        e.Cidade,
                                        e.Complemento,
                                        e.CEP
                                    FROM dbo.Cliente c
                                    LEFT JOIN Endereco e ON c.IdCliente = e.IdCliente
                                    WHERE c.IdCliente = @IdCliente";

            var ClienteDictionary = new Dictionary<int, Cliente>();

            var clientes = connection.Query<Cliente, Endereco, Cliente>(
                selectQuery,
                (c, e) =>
                {
                    if (!ClienteDictionary.TryGetValue(c.IdCliente, out var cliente))
                    {
                        cliente = c;
                        cliente.Endereco = new List<Endereco>();
                        ClienteDictionary.Add(c.IdCliente, cliente);
                    }

                    if (e != null)
                    {
                        cliente.Endereco.Add(e);
                    }

                    return cliente;
                }, new { IdCliente = idCliente },
                splitOn: "IdEndereco"
            ).ToList();
            return ClienteDictionary.Values.FirstOrDefault()!;
            //using var connection = await _connectionFactory.CreateConnectionAsync(DatabaseConnectionName.DB_FIAP_STORE);
            //var query = "SELECT * FROM Cliente WHERE IdCliente = @IdCliente";
            //return connection.Query<Cliente>(query, new { IdCliente = idCliente }).FirstOrDefault()!;
        }
    }
}

