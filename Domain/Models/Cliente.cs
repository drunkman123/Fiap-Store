﻿using BCrypt.Net;
using Domain.Enum;
using System.Security.Cryptography;

namespace Domain.Models
{
    public class Cliente
    {
        public int IdCliente { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }        
        public DateTime DataNascimento { get; set; }
        public TipoPermissao IdPermissao { get; set; }
        public ICollection<Endereco>? Endereco { get; set; }
        public ICollection<Pedido>? Pedidos { get; set; }

        public Cliente()
        {

        }

        //CadastrarClienteRequest
        public Cliente(string nome, string cpf, string telefone, string email, string password, DateTime dataNascimento, Endereco endereco)
        {
            Nome = nome; 
            CPF = cpf; 
            Telefone = telefone;
            Email = email;
            IdPermissao = TipoPermissao.Cliente;
            Password = HashPassword(password);
            Endereco = new List<Endereco>
            {
                endereco
            };
            DataNascimento = dataNascimento;
        }

        public Cliente(string telefone, string email, string password, int idCliente)
        {
            Telefone = telefone;
            Email = email;
            Password = HashPassword(password);
            IdCliente = idCliente;
        }
        private string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }
    }
}
