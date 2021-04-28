using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleDeGastos.Models
{
    public class Conta
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public string Descricao { get; set; }
        public Usuario Usuario { get; set; }
        public Categoria Categoria { get; set; }
        public TipoConta TipoConta { get; set; }
    }
}
