using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Enum
{
    public enum TipoPagamento
    {
        Cartao = 1,
        Dinheiro = 2,
        Pix = 3
    }

    public static class Pagamentos
    {
        public const string Cartao = "Cartão";
        public const string Dinheiro = "Dinheiro";
        public const string Pix = "Pix";
    }
}
