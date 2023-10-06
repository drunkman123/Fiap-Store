using Application.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Application.Mappings;
using Application.DTO;
using Application.Repositories;
using Microsoft.AspNetCore.Authorization;
using Domain.Enum;
using Microsoft.AspNetCore.Authorization.Infrastructure;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace fiap_store.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService _clienteService;

        public ClienteController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        // GET: api/<ClienteController>
        [HttpGet]
        [Authorize(Roles = Permissoes.Administrador)]
        public async Task<IActionResult> GetAll()
        {
            IEnumerable<Cliente> cliente = await _clienteService.ObterTodos();
            var Clientes = cliente.ToAllClientsResponse();
            return Ok(Clientes);
        }

        // GET api/<ClienteController>/5
        [HttpGet("{idCliente}")]
        [Authorize]
        public async Task<IActionResult> GetById(int idCliente)
        {
            var userIdClaim = User.FindFirst("IdCliente");

            if (userIdClaim == null || userIdClaim.Value != idCliente.ToString())
                return Forbid();
            
            Cliente cliente = await _clienteService.GetById(idCliente);

            return Ok(cliente.ToClienteResponse());
        }

        // POST api/<ClienteController>
        [HttpPost]
        public async Task<IActionResult> Cadastrar([FromBody] CadastrarClienteRequest cliente)
        {
            if (await ExistsClient(cliente.CPF))
                return BadRequest(new { erro = "CPF já cadastrado." });

            var clienteDomain = cliente.ToClienteDomain();
            
            var id = await _clienteService.Cadastrar(clienteDomain);

            var mensagem = $"Cliente cadastrado com sucesso! | Id: {id} | Nome: {cliente.Nome}";
            return Ok(mensagem);
        }

        // POST api/<ClienteController>
        [HttpPost("{idCliente}")]
        [Authorize]
        public async Task<IActionResult> AdicionarEndereco([FromBody] Endereco endereco, int idCliente)
        {
            var userIdClaim = User.FindFirst("IdCliente");

            if (userIdClaim == null || userIdClaim.Value != idCliente.ToString())
                return Forbid();
            
            await _clienteService.AdicionarEndereco(idCliente, endereco);

            var mensagem = $"Endereço adicionado com sucesso! | IdCliente: {idCliente}";

            return Ok(mensagem);
        }

        // PUT api/<ClienteController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ClienteController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {

        }

        [HttpGet("{cpf}")]
        public async Task<bool> ExistsClient(string cpf)
        {
            if(cpf.Length != 11)
                return false;
            
            return await _clienteService.ExistsClient(cpf);
        }
    }
}
