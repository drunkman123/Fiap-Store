﻿using Application.DTO;
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

        public PedidoController(IPedidoService pedidoService)
        {
            _pedidoService = pedidoService;
        }

        // POST api/<PedidoController>
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> GerarPedido([FromBody] GerarPedidoRequest gerarPedido)
        {
            var pedido = gerarPedido.ToPedidoDomain(Convert.ToInt32(User.FindFirst("IdCliente")));
            

            var idPedido = await _pedidoService.Cadastrar(pedido);

            var Pagamento = "Efetuar o pagamento";

            var mensagem = $"Pedido cadastrado com sucesso! | Id: {idPedido}";

            return Ok(mensagem);
        }
        // POST api/<PedidoController>
        [HttpGet()]
        [Authorize]
        public async Task<IActionResult> ObterTodosPedidosPorCliente()
        {
            var userIdClaim = User.FindFirst("IdCliente");

            if (userIdClaim == null)
                return Forbid();

            IEnumerable<Pedido> pedidos = await _pedidoService.ObterTodosById(Convert.ToInt32(userIdClaim));

            return Ok(pedidos.ToOrdersResponse());
        }
        // POST api/<PedidoController>
        [HttpGet()]
        [Authorize(Roles = Permissoes.Administrador)]
        public async Task<IActionResult> ObterTodos()
        {
            IEnumerable<Pedido> pedidos = await _pedidoService.ObterTodos();

            return Ok(pedidos.ToOrdersResponse());
        }
    }
}