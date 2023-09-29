using Application.DTO;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Token
{
    public interface ITokenRepository
    {
        Task<Cliente> ObterJWTCliente(string cpf);

    }
}
