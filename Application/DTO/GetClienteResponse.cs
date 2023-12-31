﻿using Domain.Enum;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO
{
    public class GetClienteResponse
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public DateOnly DataNascimento { get; set; }
        public string Permissao { get; set; }
        public ICollection<Endereco> Endereco { get; set; }

    }
}
