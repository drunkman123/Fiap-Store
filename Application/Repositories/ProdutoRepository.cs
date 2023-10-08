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
            using var transaction = connection.BeginTransaction();
            try
            {
                string insertProdutoQuery = @"
                INSERT INTO dbo.Produto (IdTipoProduto, Nome, Preco, Descricao) 
                OUTPUT INSERTED.[IdProduto]
                VALUES (@IdTipoProduto, @Nome, @Preco, @Descricao);";
                int idProduto = connection.QuerySingle<int>(insertProdutoQuery, produto, transaction);

                string insertEstoqueQuery = @"
                INSERT INTO dbo.Estoque (IdProduto, Qtde) 
                VALUES (@IdProduto, @Qtde);";
                connection.Execute(insertEstoqueQuery, new { IdProduto = idProduto,Qtde = produto.Quantidade }, transaction);
                transaction.Commit();
                return idProduto;
            }
            catch (Exception)
            {
                transaction.Rollback();
                throw;
            }
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
                                SELECT
	                                p.IdProduto,
	                                p.Nome,
	                                p.Preco,
	                                p.IdTipoProduto,
	                                p.Descricao,
	                                e.Qtde as Quantidade
                                FROM
	                                dbo.Produto p
	                                INNER JOIN Estoque e ON p.IdProduto = e.IdProduto";
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
