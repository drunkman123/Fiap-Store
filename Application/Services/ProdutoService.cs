using Application.Interfaces;
using Application.Repositories;
using Dapper;
using Domain.Models;
using fiap_store.Infraestructure;


namespace Application.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoService(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }
        public void Alterar(Produto entidade)
        {
            throw new NotImplementedException();
        }

        public async Task<int> Cadastrar(Produto produto)
        {
            return await _produtoRepository.Cadastrar(produto);
        }

        public async Task<int> CadastrarTipoProduto(string tipoProduto)
        {
            return await _produtoRepository.CadastrarTipoProduto(tipoProduto);
        }

        public void Deletar(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Produto> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IList<Produto> ObterTodos()
        {
            throw new NotImplementedException();
        }
    }
}
