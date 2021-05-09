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

        [Required(ErrorMessage = "O campo 'Data' é obrigatório")]
        [Display(Name = "Data")]
        [DataType(DataType.Date, ErrorMessage = "Formato de data inválido.")]       
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Data { get; set; }

        [Required(ErrorMessage = "O campo 'Descrição' é obrigatório")]
        public string Descricao { get; set; }
        public Usuario Usuario { get; set; }
        public int UsuarioId { get; set; }
        public Categoria Categoria { get; set; }
        public int CategoriaId { get; set; }
        public TipoConta TipoConta { get; set; }
        public int TipoContaId { get; set; }

        [Required(ErrorMessage = "O campo 'Valor' é obrigatório")]
        [DataType(DataType.Currency, ErrorMessage = "O valor informado não é válido.")]
        //[DisplayFormat(DataFormatString = "{0:C}")]
        //[DataType(DataType.Currency)]
        [Range(1, Double.PositiveInfinity, ErrorMessage = "O valor deve ser maior que R$ 0,00.")]
        public  double Valor { get; set; }
    }
}
