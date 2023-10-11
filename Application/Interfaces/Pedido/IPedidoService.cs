using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IPedidoService
    {
        Task<IEnumerable<Pedido>> ObterTodosById(int id);
        Task<IEnumerable<Pedido>> ObterTodos();
        Task<Pedido> GetById(int id);
        Task<int> Cadastrar(Pedido entidade);
        void Alterar(Pedido entidade);
        void Deletar(int id);
    }
}
