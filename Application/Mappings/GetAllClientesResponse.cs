using Application.DTO;
using Domain.Models;
using System;

namespace Application.Mappings
{
    public static class GetAllClientesResponse
    {
        public static IList<GetClienteResponse> ToAllClientsResponse(this IEnumerable<Cliente> clientes)
        {
            var Clientes = new List<GetClienteResponse>();
            foreach(Cliente cliente in clientes)
            {
                GetClienteResponse clienteResponse = new GetClienteResponse();
                clienteResponse.Id = cliente.IdCliente;
                clienteResponse.Nome = cliente.Nome;
                clienteResponse.CPF = cliente.CPF;
                clienteResponse.Telefone = cliente.Telefone;
                clienteResponse.Email = cliente.Email;
                clienteResponse.Endereco = cliente.Endereco!;
                clienteResponse.DataNascimento = DateOnly.FromDateTime(cliente.DataNascimento)!;
                clienteResponse.Permissao = cliente.IdPermissao.ToString();
                Clientes.Add(clienteResponse);
            }
            

            return Clientes;

        }
    }
}
