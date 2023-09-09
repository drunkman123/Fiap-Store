using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Item
    {
        public int IdItem { get; set; }
        public int IdPedido { get; set; }
        public int IdProduto { get; set; }
        public decimal Valor { get; set; }
        public int Quantidade { get; set; }
        public decimal SubTotal { get; set; }
    }
}
