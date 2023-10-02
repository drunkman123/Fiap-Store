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
    public class PedidoRepository : IPedidoRepository
    {
        private readonly IDbConnectionFactory _connectionFactory;

        public PedidoRepository(IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }
        public void Alterar(Pedido entidade)
        {
            throw new NotImplementedException();
        }

        public Task<int> Cadastrar(Pedido entidade)
        {
            throw new NotImplementedException();
        }

        public void Deletar(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Exists(Pedido cliente)
        {
            throw new NotImplementedException();
        }

        public Task<Pedido> GetById(int id)
        {
            //using var connection = await _connectionFactory.CreateConnectionAsync(DatabaseConnectionName.DB_FIAP_STORE);
            //string selectQuery = @"
            //                        SELECT
            //                            c.IdCliente,
            //                            c.Nome,
            //                            c.CPF,
            //                            c.Telefone,
            //                            c.Email,
            //                            p.IdPedido,
            //                            p.DataPedido,
            //                            p.ValorTotal
            //                        FROM dbo.Cliente c
            //                        LEFT JOIN Pedido p ON c.IdCliente = p.IdCliente
            //                        WHERE c.IdCliente = @IdCliente";

            //var ClienteDictionary = new Dictionary<int, Cliente>();

            //var clientes = connection.Query<Cliente, Pedido, Cliente>(
            //    selectQuery,
            //    (c, p) =>
            //    {
            //        if (!ClienteDictionary.TryGetValue(c.IdCliente, out var cliente))
            //        {
            //            cliente = c;
            //            cliente.Pedidos = new List<Pedido>();
            //            ClienteDictionary.Add(c.IdCliente, cliente);
            //        }

            //        if (p != null)
            //        {
            //            cliente.Pedidos.Add(p);
            //        }

            //        return cliente;
            //    }, new { IdCliente = id },
            //    splitOn: "IdPedido"
            //).ToList();
            //return ClienteDictionary.Values.FirstOrDefault()!;
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Item>> GetPrecosProdutosPedidos(IEnumerable<Item> items)
        {
            var idProdutos = items.Select(x => x.IdProduto).AsEnumerable();
            using var connection = await _connectionFactory.CreateConnectionAsync(DatabaseConnectionName.DB_FIAP_STORE);
            string query = "SELECT IdProduto, Preco FROM dbo.Produto WHERE IdProduto IN @IdsProdutos";
            return await connection.QueryAsync<Item>(query, new { IdsProdutos = idProdutos });


        }

        public Task<IEnumerable<Pedido>> ObterTodos()
        {
            throw new NotImplementedException();
        }
    }
}
