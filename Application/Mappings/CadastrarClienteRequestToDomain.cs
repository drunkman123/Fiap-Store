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
        public static Cliente ToClientDomain(this CadastrarClienteRequest cadastrarClienteRequest)
        {
            Cliente cliente = new Cliente(cadastrarClienteRequest.Nome, 
                                            cadastrarClienteRequest.CPF, 
                                            cadastrarClienteRequest.Telefone, 
                                            cadastrarClienteRequest.Email,
                                            cadastrarClienteRequest.Password,
                                            cadastrarClienteRequest.DataNascimento,
                                            cadastrarClienteRequest.Endereco) ;
            return cliente;

        }
    }
}
