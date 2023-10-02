using Application.DTO;
using Application.Interfaces;
using Application.Mappings;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace fiap_store.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        private readonly IPedidoService _pedidoService;

        public PedidoController(IPedidoService pedidoService)
        {
            _pedidoService = pedidoService;
        }
        // GET: api/<PedidoController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<PedidoController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<PedidoController>
        [HttpPost]
        public async Task<IActionResult> GerarPedido([FromBody] GerarPedidoRequest gerarPedido)
        {
            var userIdClaim = User.FindFirst("IdCliente");
            if (userIdClaim == null || userIdClaim.Value != gerarPedido.IdCliente.ToString())
                return Forbid();
            IEnumerable<Item> items = gerarPedido.ToItemDomain();
            var order = gerarPedido.ToPedidoDomain();
            var precoProdutos = await _pedidoService.GetPrecosProdutosPedidos(items);
            return Ok("teste");

        }

        // PUT api/<PedidoController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PedidoController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
