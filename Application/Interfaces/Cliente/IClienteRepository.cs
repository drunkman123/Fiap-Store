using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IClienteRepository : IRepository<Cliente>
    {
        Task<bool> AdicionarEndereco(int clienteId,Endereco endereco);
    }
}
