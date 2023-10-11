using Application.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Application.Mappings;
using Application.DTO;
using Microsoft.AspNetCore.Authorization;
using Domain.Enum;

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
        public async Task<IActionResult> Get()
        {
            var userIdClaim = User.FindFirst("IdCliente");

            if (userIdClaim == null)           
                return Forbid();
            
            Cliente cliente = await _clienteService.Get(Convert.ToInt32(userIdClaim));

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
        [HttpPost()]
        [Authorize]
        public async Task<IActionResult> AdicionarEndereco([FromBody] Endereco endereco)
        {
            var userIdClaim = Convert.ToInt32(User.FindFirst("IdCliente"));

            if (userIdClaim == null)
                return Forbid();
            
            await _clienteService.AdicionarEndereco(userIdClaim, endereco);

            var mensagem = $"Endereço adicionado com sucesso! | IdCliente: {userIdClaim}";

            return Ok(mensagem);
        }

        // PUT api/<ClienteController>/5
        [HttpPut()]
        [Authorize]
        public async Task<IActionResult> Put([FromBody] AlterarClienteRequest dadosAlteracao)
        {
            var userIdClaim = Convert.ToInt32(User.FindFirst("IdCliente"));
            var cliente = dadosAlteracao.ToClienteDomain(userIdClaim);
            _clienteService.Alterar(cliente);
            return Ok();

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
