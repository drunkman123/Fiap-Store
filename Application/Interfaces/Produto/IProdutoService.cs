using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IProdutoService
    {
        Task<int> RegisterTypeProduct(string tipoProduto);
        Task<IEnumerable<TipoProduto>> GetAllTypesProducts();
        Task<IEnumerable<Produto>> GetAll();
        Task<Produto> GetById(int id);
        Task<int> Register(Produto entidade);
        void Update(Produto entidade);
        void Delete(int id);
    }
}
