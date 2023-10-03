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
        Task<int> CadastrarTipoProduto(string tipoProduto);
        Task<IEnumerable<TipoProduto>> ObterTodosTiposProdutos();
        Task<IEnumerable<Produto>> ObterTodos();
        Task<Produto> GetById(int id);
        Task<int> Cadastrar(Produto entidade);
        void Alterar(Produto entidade);
        void Deletar(int id);
    }
}
