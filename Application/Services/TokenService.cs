using Application.DTO;
using Application.Interfaces.Token;
using Domain.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Application.Services
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _configuration;
        private readonly ITokenRepository _tokenRepository;

        public TokenService(IConfiguration configuration, ITokenRepository tokenRepository)
        {
            _configuration = configuration;
            _tokenRepository = tokenRepository;
        }

        public string GenerateToken(Cliente usuario)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration.GetValue<string>("JWTSecret")!);
            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim("IdCliente",usuario.IdCliente.ToString()),
                    new Claim("Nome", usuario.Nome!),
                    new Claim("CPF", usuario.CPF!),
                    new Claim(ClaimTypes.Role, usuario.IdPermissao.ToString()),
                }),
                Expires = DateTime.UtcNow.AddHours(8),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);


        }
        public async Task<Cliente> VerifyLogin(string cpf)
        {

            return await _tokenRepository.GetJWTClient(cpf);
        }
    }
}
