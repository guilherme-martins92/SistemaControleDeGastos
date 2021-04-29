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
        public int UsuarioId { get; set; }
        public Categoria Categoria { get; set; }
        public int CategoriaId { get; set; }
        public TipoConta TipoConta { get; set; }
        public int TipoContaId { get; set; }
        public  double Valor { get; set; }
    }
}
