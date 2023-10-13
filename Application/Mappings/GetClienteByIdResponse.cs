using Application.DTO;
using Domain.Models;
using System;

namespace Application.Mappings
{
    public static class GetClienteByIdResponse
    {
        public static GetClienteResponse ToClientResponse(this Cliente clienteDomain)
        {
            GetClienteResponse clienteResponse = new GetClienteResponse();
            clienteResponse.Id = clienteDomain.IdCliente;
            clienteResponse.Nome = clienteDomain.Nome;
            clienteResponse.CPF = clienteDomain.CPF;
            clienteResponse.Telefone = clienteDomain.Telefone;
            clienteResponse.Email = clienteDomain.Email;
            clienteResponse.Endereco = clienteDomain.Endereco!;
            clienteResponse.DataNascimento = DateOnly.FromDateTime(clienteDomain.DataNascimento)!;
            clienteResponse.Permissao = clienteDomain.IdPermissao.ToString();

            return clienteResponse;

        }
    }
}
