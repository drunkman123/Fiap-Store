using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Enum
{
    public enum TipoPermissao
    {
        Administrador = 1,
        Cliente = 2
    }

    public static class Permissoes
    {
        public const string Administrador = "Administrador";
        public const string Cliente = "Cliente";
    }
}
