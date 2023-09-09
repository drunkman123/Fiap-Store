using Application.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Application.Mappings;
using Application.DTO;

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
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ClienteController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            Cliente cliente = await _clienteService.GetById(id);
            return Ok(cliente.ToClienteResponse());
        }

        // POST api/<ClienteController>
        [HttpPost]
        public async Task<IActionResult> Cadastrar([FromBody] CadastrarClienteRequest cliente)
        {
            var id = await _clienteService.Cadastrar(cliente.ToClienteDomain());
            var mensagem = $"Usuário criado com sucesso! | Id: {id} | Nome: {cliente.Nome}";
            return Ok(mensagem);
        }

        // POST api/<ClienteController>
        [HttpPost("{clienteId}")]
        public async Task<IActionResult> AdicionarEndereco([FromBody] Endereco endereco, int clienteId)
        {
            await _clienteService.AdicionarEndereco(clienteId,endereco);
            var mensagem = $"Endereço adicionado com sucesso! | ClienteId: {clienteId}";
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
    }
}
