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
        Task<bool> AddAddress(int clienteId,Endereco endereco);
        Task<bool> ExistsClient(string cpf);
        Task<Cliente> Get(int id);

    }
}
