using Application.Interfaces;
using Domain.Models;


namespace Application.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoService(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }
        public void Update(Produto entidade)
        {
            throw new NotImplementedException();
        }

        public async Task<int> Register(Produto produto)
        {
            return await _produtoRepository.Register(produto);
        }

        public async Task<int> RegisterTypeProduct(string tipoProduto)
        {
            return await _produtoRepository.RegisterTypeProducts(tipoProduto);
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Produto> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Produto>> GetAll()
        {
            return await _produtoRepository.GetAll();
        }

        public async Task<IEnumerable<TipoProduto>> GetAllTypesProducts()
        {
            return await _produtoRepository.GetAllTypesProducts();
        }
    }
}
