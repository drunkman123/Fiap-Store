using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Avaliacao
    {
        public Cliente Cliente { get; set; }
        public Produto Produto { get; set; }
        public string? Nota { get; set; }
        public string? Comentario { get; set; }
    }
}
