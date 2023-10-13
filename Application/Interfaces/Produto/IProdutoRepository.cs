using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IProdutoRepository : IRepository<Produto>
    {
        Task<int> RegisterTypeProducts(string tipoProduto);
        Task<IEnumerable<TipoProduto>> GetAllTypesProducts();

    }
}
