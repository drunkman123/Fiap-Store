using Application.DTO;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mappings
{
    public static class CadastrarClienteRequestToDomain
    {
        public static Cliente ToClienteDomain(this CadastrarClienteRequest cadastrarClienteRequest)
        {           
            Cliente cliente = new Cliente();
            cliente.Endereco = new List<Endereco>();
            cliente.Nome = cadastrarClienteRequest.Nome;
            cliente.CPF = cadastrarClienteRequest.CPF;
            cliente.Telefone = cadastrarClienteRequest.Telefone;
            cliente.Email = cadastrarClienteRequest.Email;
            cliente.Endereco.Add(cadastrarClienteRequest.Endereco);            
            cliente.Password = cadastrarClienteRequest.Password;

            return cliente;

        }
    }
}
