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
        Task<bool> AdicionarEndereco(int clienteId, Endereco endereco);
        Task<bool> ExistsClient(string cpf);
        Task<IEnumerable<Cliente>> ObterTodos();
        Task<Cliente> Get(int id);
        Task<int> Cadastrar(Cliente entidade);
        void Alterar(Cliente entidade);
        void Deletar(int id);
    }
}
