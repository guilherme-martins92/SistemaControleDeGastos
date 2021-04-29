using ControleDeGastos.Library.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ControleDeGastos.Models
{
    public class TipoConta
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo 'Nome' é obrigatório!")]
        [UnicoNomeTipoConta]
        public string Nome { get; set; }
        public ICollection<Conta> contas { get; set; } = new List<Conta>();
    }
}
