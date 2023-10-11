using Application.DTO;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mappings
{
    public static class AlterarClienteRequestToDomain
    {
        public static Cliente ToClienteDomain(this AlterarClienteRequest cadastrarClienteRequest, int idCliente)
        {
            Cliente cliente = new Cliente(cadastrarClienteRequest.Telefone, cadastrarClienteRequest.Email, cadastrarClienteRequest.Password, idCliente);
            return cliente;
        }
    }
}
