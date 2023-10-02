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
        // GET: api/<PagamentoController>
        [HttpGet]
        public async Task<IEnumerable<Produto>> ObterTodosProdutos()
        {
            return await _produtoService.ObterTodos();
        }

        // GET api/<PagamentoController>/5
        [HttpGet()]
        public async Task<IEnumerable<TipoProduto>> GetTiposProduto()
        {
            return await _produtoService.ObterTodosTiposProdutos();
        }

        // POST api/<PagamentoController>
        [HttpPost]
        [Authorize(Roles = Permissoes.Administrador)]
        public async Task<IActionResult> Cadastrar([FromBody] CadastrarProdutoRequest produtoRequest)
        {
            var produto = produtoRequest.ToProdutoDomain();
            var id = await _produtoService.Cadastrar(produto);
            var mensagem = $"Produto criado com sucesso! | Id: {id} | Nome: {produto.Nome}";
            return Ok(mensagem);
        }

        // POST api/<PagamentoController>
        [HttpPost]
        [Authorize(Roles = Permissoes.Administrador)]
        public async Task<IActionResult> CadastrarTipoProduto([FromBody] CadastrarTipoProdutoRequest tipoProduto)
        {
            var id = await _produtoService.CadastrarTipoProduto(tipoProduto.Tipo.ToUpper());
            var mensagem = $"Tipo de Produto criado com sucesso! | Id: {id} | Nome: {tipoProduto.Tipo}";
            return Ok(mensagem);
        }

        // PUT api/<PagamentoController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PagamentoController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
