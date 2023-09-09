using Application.DTO;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mappings
{
    public static class ClienteDomainToResponse
    {
        public static GetClienteResponse ToClienteResponse(this Cliente clienteDomain)
        {
            GetClienteResponse clienteResponse = new GetClienteResponse();
            clienteResponse.Nome = clienteDomain.Nome;
            clienteResponse.CPF = clienteDomain.CPF;
            clienteResponse.Telefone = clienteDomain.Telefone;
            clienteResponse.Email = clienteDomain.Email;
            clienteResponse.Endereco = clienteDomain.Endereco!;

            return clienteResponse;

        }
    }
}
