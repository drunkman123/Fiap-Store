using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IPedidoRepository : IRepository<Pedido>
    {
        Task<IEnumerable<Item>> GetPrecosProdutosPedidos(List<Item> items);
        Task<IEnumerable<Pedido>> ObterTodosPedidosById(int id);

    }
}
