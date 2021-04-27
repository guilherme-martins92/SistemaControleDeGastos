﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleDeGastos.Models
{
    public class TipoConta
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public ICollection<Conta> contas { get; set; } = new List<Conta>();
    }
}
