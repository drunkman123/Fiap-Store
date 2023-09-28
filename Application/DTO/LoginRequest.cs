using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO
{
    public class LoginRequest
    {
        public string CPF { get; set; }
        public string Password { get; set; }
    }
}
