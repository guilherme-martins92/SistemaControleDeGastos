using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ControleDeGastos.Models
{
    public class Conta
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} required")]
        [Display(Name = "Data")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Data { get; set; }

        [Required(ErrorMessage = "{0} required")]
        public string Descricao { get; set; }
        public Usuario Usuario { get; set; }
        public int UsuarioId { get; set; }
        public Categoria Categoria { get; set; }
        public int CategoriaId { get; set; }
        public TipoConta TipoConta { get; set; }
        public int TipoContaId { get; set; }

        [Required(ErrorMessage = "{0} required")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public  double Valor { get; set; }
    }
}
