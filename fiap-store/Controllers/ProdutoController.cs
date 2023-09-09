using Application.DTO;
using Application.Interfaces;
using Application.Services;
using Domain.Models;
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
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<PagamentoController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<PagamentoController>
        [HttpPost]
        public async Task<IActionResult> Cadastrar([FromBody] Produto produto)
        {
            var id = await _produtoService.Cadastrar(produto);
            var mensagem = $"Produto criado com sucesso! | Id: {id} | Nome: {produto.Nome}";
            return Ok(mensagem);
        }

        // POST api/<PagamentoController>
        [HttpPost]
        public async Task<IActionResult> CadastrarTipoProduto([FromBody] TipoProduto tipoProduto)
        {
            var id = await _produtoService.CadastrarTipoProduto(tipoProduto.Tipo);
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
