﻿using Application.DTO;
using Application.Interfaces.Token;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace fiap_store.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ITokenService _tokenService;

        public LoginController(ITokenService tokenService)
        {
            _tokenService = tokenService;
        }

        [HttpPost]
        public async Task<IActionResult> Authenticate([FromBody] LoginRequest loginRequest)
        {
            Cliente cliente = await _tokenService.VerifyLogin(loginRequest.CPF);
            if (cliente == null)
                return NotFound(new { mensagem = "Usuário não cadastrado." });
            var success = BCrypt.Net.BCrypt.Verify(loginRequest.Password, cliente.Password);
            if (success == false)
                return BadRequest(new { mensage = "CPF ou Senha inválidos." });
            var token = _tokenService.GenerateToken(cliente);
            cliente.Password = null;
            return Ok(new
            {
                Usuario = cliente.CPF,
                Name = cliente.Nome,
                Token = token
            });
        }

        [HttpPost]
        public async Task<IActionResult> ResetPassword([FromBody] ResetSenhaRequest resetSenhaRequest)
        {
            bool alteraSenha = true;
            if (alteraSenha)
                return Ok("Senha resetada, verifique o e-mail cadastrado.");
            else
                return BadRequest("Dados inválidos.");
        }

    }
}
