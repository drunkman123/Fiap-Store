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
            Cliente cliente = new Cliente(cadastrarClienteRequest.Nome, 
                                            cadastrarClienteRequest.CPF, 
                                            cadastrarClienteRequest.Telefone, 
                                            cadastrarClienteRequest.Email,
                                            cadastrarClienteRequest.Password,
                                            cadastrarClienteRequest.DataNasc,
                                            cadastrarClienteRequest.Endereco) ;
            //cliente.Endereco = new List<Endereco>();
            //cliente.Nome = cadastrarClienteRequest.Nome;
            //cliente.CPF = cadastrarClienteRequest.CPF;
            //cliente.Telefone = cadastrarClienteRequest.Telefone;
            //cliente.Email = cadastrarClienteRequest.Email;
            //cliente.Endereco.Add(cadastrarClienteRequest.Endereco);
            //cliente.Salt = cliente.GenerateSalt();
            //cliente.Password = cliente.HashPassword(cadastrarClienteRequest.Password, cliente.Salt);

            return cliente;

        }
    }
}
