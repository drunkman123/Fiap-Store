using Application.DTO;
using Application.Interfaces;
using Application.Mappings;
using Domain.Enum;
using Domain.Models;
using Microsoft.AspNetCore.Authorization;
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

        // POST api/<PedidoController>
        [HttpPost]
        //[Authorize]
        public async Task<IActionResult> GerarPedido([FromBody] GerarPedidoRequest gerarPedido)
        {
            //var userIdClaim = User.FindFirst("IdCliente");
            //if (userIdClaim == null || userIdClaim.Value != gerarPedido.IdCliente.ToString())
            //    return Forbid();
            var pedido = gerarPedido.ToPedidoDomain();

            var idPedido = await _pedidoService.Cadastrar(pedido);

            var mensagem = $"Pedido cadastrado com sucesso! | Id: {idPedido}";


            return Ok(mensagem);

        }
    }
}
