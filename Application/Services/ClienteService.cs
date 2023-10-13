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

        public async Task<bool> AddAddress(int clienteId, Endereco endereco)
        {
            return await _clienteRepository.AddAddress(clienteId,endereco);
        }

        public void Update(Cliente entidade)
        {
            _clienteRepository.Update(entidade);
        }

        public async Task<int> Register(Cliente entidade)
        {
                return await _clienteRepository.Register(entidade);
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> ExistsClient(string cpf)
        {
            return await _clienteRepository.ExistsClient(cpf);
        }

        public async Task<Cliente> Get(int id)
        {
            return await _clienteRepository.Get(id);
        }

        public async Task<IEnumerable<Cliente>> GetAll()
        {
            return await _clienteRepository.GetAll();
        }

    }
}
