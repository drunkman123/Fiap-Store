using Application.DTO;
using Application.Interfaces;
using Application.Mappings;
using Application.Services;
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
        private readonly IProdutoRepository _produtoRepository;

        public PedidoController(IPedidoService pedidoService, IProdutoRepository produtoRepository)
        {
            _pedidoService = pedidoService;
            _produtoRepository = produtoRepository;
        }

        // POST api/<PedidoController>
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> GenerateOrder([FromBody] GerarPedidoRequest gerarPedido)
        {
            var pedido = gerarPedido.ToOrderDomain(Convert.ToInt32(User.FindFirst("IdCliente").Value));
            var orderItems = gerarPedido.IdProdutoXQuantidade.Select(x => (x.IdProduto, x.Quantidade));
            var products = await _produtoRepository.GetAll();
            var withoutStock = orderItems.FirstOrDefault(i => products.Any(p => p.IdProduto == i.IdProduto && p.Quantidade < i.Quantidade));

            if (withoutStock is {})
                return BadRequest($"Produto com id {withoutStock.IdProduto} sem estoque");

            var idPedido = await _pedidoService.Register(pedido);

            var Pagamento = "Efetuar o pagamento";

            var mensagem = $"Pedido cadastrado com sucesso! | Id: {idPedido}";

            return Ok(mensagem);
        }
        // POST api/<PedidoController>
        [HttpGet()]
        [Authorize]
        public async Task<IActionResult> GetAllOrdersByCustomer()
        {
            var userIdClaim = User.FindFirst("IdCliente");

            if (userIdClaim == null)
                return Forbid();

            IEnumerable<Pedido> pedidos = await _pedidoService.GetAllById(Convert.ToInt32(userIdClaim.Value));

            return Ok(pedidos.ToOrdersResponse());
        }
        // POST api/<PedidoController>
        [HttpGet()]
        [Authorize(Roles = Permissoes.Administrador)]
        public async Task<IActionResult> GetAll()
        {
            IEnumerable<Pedido> pedidos = await _pedidoService.GetAll();

            return Ok(pedidos.ToOrdersResponse());
        }
    }
}