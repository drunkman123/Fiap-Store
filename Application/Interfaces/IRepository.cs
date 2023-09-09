using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IRepository<T> where T : class
    {
        IList<T> ObterTodos();
        Task<T> GetById(int id);
        Task<int> Cadastrar(T entidade);
        void Alterar(T entidade);
        void Deletar(int id);

    }
}
