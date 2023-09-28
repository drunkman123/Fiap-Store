using Application.DTO;
using Application.Interfaces;
using Application.Interfaces.Token;
using Application.Repositories;
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
        public async Task<IActionResult> Autenticar([FromBody] LoginRequest loginRequest)
        {
            loginRequest.Password = BCrypt.Net.BCrypt.HashPassword(loginRequest.Password);

            Cliente cliente = await _tokenService.VerifyLogin(loginRequest);
            if (cliente == null)
                return NotFound(new { mensagem = "CPF ou Senha inválido." });
            var token = _tokenService.GerarToken(cliente);
            cliente.Password = null;
            return Ok(new
            {
                Usuario = cliente.CPF,
                Token = token
            });
        }

    }
}
