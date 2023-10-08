using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO
{
    public class GerarPedidoRequest
    {
        //public int IdCliente { get; set; }
        public List<LinkedListItem> IdProdutoXQuantidade { get; set; }

    }
    public class LinkedListItem
    {
        public int IdProduto { get; set; }
        public int Quantidade { get; set; }
    }
    
}
