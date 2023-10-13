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
        Task<IEnumerable<Item>> GetOrderProductsPrices(List<Item> items);
        Task<IEnumerable<Pedido>> GetAllOrderById(int id);

    }
}
