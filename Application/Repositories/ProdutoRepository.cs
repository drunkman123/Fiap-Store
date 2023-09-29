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
                INSERT INTO dbo.Produto (IdTipo, Nome, Preco, Descricao) 
                OUTPUT INSERTED.[Id]
                VALUES (@IdTipo, @Nome, @Preco, @Descricao);";
            return connection.QuerySingle<int>(insertQuery, produto);
        }

        public async Task<int> CadastrarTipoProduto(string tipoProduto)
        {
            using var connection = await _connectionFactory.CreateConnectionAsync(DatabaseConnectionName.DB_FIAP_STORE);
            string insertQuery = @"
                INSERT INTO dbo.TipoProduto (TipoProduto) 
                OUTPUT INSERTED.[IdTipoProduto]
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

        public IList<Produto> ObterTodos()
        {
            throw new NotImplementedException();
        }
    }
}
