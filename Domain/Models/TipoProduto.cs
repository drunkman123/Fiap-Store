﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class TipoProduto
    {
        public int Id { get; set; }
        public string Tipo { get; set; }
    }
}
