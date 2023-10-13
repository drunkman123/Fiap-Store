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
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoService _produtoService;

        public ProdutoController(IProdutoService produtoService)
        {
            _produtoService = produtoService;
        }
        [HttpGet]
        public async Task<IEnumerable<Produto>> GetAllProducts()
        {
            return await _produtoService.GetAll();
        }

        [HttpGet()]
        public async Task<IEnumerable<TipoProduto>> GetTypeProducts()
        {
            return await _produtoService.GetAllTypesProducts();
        }

        [HttpPost]
        [Authorize(Roles = Permissoes.Administrador)]
        public async Task<IActionResult> Register([FromBody] CadastrarProdutoRequest produtoRequest)
        {
            var produto = produtoRequest.ToProductDomain();
            var id = await _produtoService.Register(produto);
            var mensagem = $"Produto criado com sucesso! | Id: {id} | Nome: {produto.Nome}";
            return Ok(mensagem);
        }

        [HttpPost]
        [Authorize(Roles = Permissoes.Administrador)]
        public async Task<IActionResult> RegisterTypeProduct([FromBody] CadastrarTipoProdutoRequest tipoProduto)
        {
            var id = await _produtoService.RegisterTypeProduct(tipoProduto.Tipo.ToUpper());
            var mensagem = $"Tipo de Produto criado com sucesso! | Id: {id} | Nome: {tipoProduto.Tipo}";
            return Ok(mensagem);
        }
    }
}
