using Application.Interfaces;
using Dapper;
using Domain.Models;
using Infrastructure.DbConnection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly IDbConnectionFactory _connectionFactory;

        public ProdutoRepository(IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }
        public void Alterar(Produto entidade)
        {
            throw new NotImplementedException();
        }

        public async Task<int> Cadastrar(Produto produto)
        {
            using var connection = await _connectionFactory.CreateConnectionAsync(DatabaseConnectionName.DB_FIAP_STORE);
            string insertQuery = @"
                INSERT INTO dbo.Produto (IdTipoProduto, Nome, Preco, Descricao) 
                OUTPUT INSERTED.[IdProduto]
                VALUES (@IdTipoProduto, @Nome, @Preco, @Descricao);";
            return connection.QuerySingle<int>(insertQuery, produto);
        }

        public async Task<int> CadastrarTipoProduto(string tipoProduto)
        {
            using var connection = await _connectionFactory.CreateConnectionAsync(DatabaseConnectionName.DB_FIAP_STORE);
            string insertQuery = @"
                INSERT INTO dbo.TipoProduto (Tipo) 
                OUTPUT INSERTED.[Id]
                VALUES (@Tipo);";
            return connection.QuerySingle<int>(insertQuery, new { Tipo = tipoProduto });
        }

        public void Deletar(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Exists(Produto cliente)
        {
            throw new NotImplementedException();
        }

        public Task<Produto> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Produto>> ObterTodos()
        {
            using var connection = await _connectionFactory.CreateConnectionAsync(DatabaseConnectionName.DB_FIAP_STORE);
            string getQuery = @"
                                SELECT IdProduto, Nome, Preco, IdTipoProduto, Descricao
                                FROM dbo.Produto";
            return await connection.QueryAsync<Produto>(getQuery);
        }

        public async Task<IEnumerable<TipoProduto>> ObterTodosTiposProdutos()
        {
            using var connection = await _connectionFactory.CreateConnectionAsync(DatabaseConnectionName.DB_FIAP_STORE);
            string getQuery = @"
                                SELECT Id, Tipo
                                FROM dbo.TipoProduto";
            return await connection.QueryAsync<TipoProduto>(getQuery);
        }

    }
}
