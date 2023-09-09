using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Enum;

namespace Domain.Models
{
    public class Pagamento
    {
        public int IdPagamento { get; set; }
        public Pedido Pedido { get; set; }
        public TipoPagamento TipoPagamento { get; set; }
        public bool Pago { get; set; }
    }
}
