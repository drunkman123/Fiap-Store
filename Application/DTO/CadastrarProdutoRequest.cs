using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO
{
    public class CadastrarProdutoRequest
    {
        //public int IdProduto { get; set; }
        public int IdTipoProduto { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public string Descricao { get; set; }
        public int Quantidade { get; set; }

    }
}
