using Application.Interfaces;
using Application.Repositories;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task<bool> AdicionarEndereco(int clienteId, Endereco endereco)
        {
            return await _clienteRepository.AdicionarEndereco(clienteId,endereco);
        }

        public void Alterar(Cliente entidade)
        {
            throw new NotImplementedException();
        }

        public async Task<int> Cadastrar(Cliente entidade)
        {
                return await _clienteRepository.Cadastrar(entidade);
        }

        public void Deletar(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> ExistsClient(string cpf)
        {
            return await _clienteRepository.ExistsClient(cpf);
        }

        public async Task<Cliente> GetById(int id)
        {
            return await _clienteRepository.GetById(id);
        }

        public IList<Cliente> ObterTodos()
        {
            throw new NotImplementedException();
        }

    }
}
