using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IClienteService
    {
        Task<bool> AddAddress(int clienteId, Endereco endereco);
        Task<bool> ExistsClient(string cpf);
        Task<IEnumerable<Cliente>> GetAll();
        Task<Cliente> Get(int id);
        Task<int> Register(Cliente entidade);
        void Update(Cliente entidade);
        void Delete(int id);
    }
}
