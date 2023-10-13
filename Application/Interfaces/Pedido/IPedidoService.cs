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
        Task<IEnumerable<Pedido>> GetAllById(int id);
        Task<IEnumerable<Pedido>> GetAll();
        Task<Pedido> GetById(int id);
        Task<int> Register(Pedido entidade);
        void Update(Pedido entidade);
        void Delete(int id);
    }
}
