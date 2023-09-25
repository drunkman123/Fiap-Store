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

        public IList<Pedido> ObterTodos()
        {
            throw new NotImplementedException();
        }
    }
}
