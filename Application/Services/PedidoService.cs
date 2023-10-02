using Application.Interfaces;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class PedidoService : IPedidoService
    {

        private readonly IPedidoRepository _pedidoRepository;

        public PedidoService(IPedidoRepository pedidoRepository)
        {
            _pedidoRepository = pedidoRepository;
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
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Item>> GetPrecosProdutosPedidos(IEnumerable<Item> items)
        {
            return await _pedidoRepository.GetPrecosProdutosPedidos(items);
        }

        public Task<IEnumerable<Pedido>> ObterTodos()
        {
            throw new NotImplementedException();
        }
    }
}
