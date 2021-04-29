
using System.Collections.Generic;


namespace ControleDeGastos.Models.ViewModels
{
    public class ContaFormViewModel
    {
        public Conta Conta { get; set; }

        public ICollection<Categoria> Categorias { get; set; }
        public ICollection<TipoConta> TipoContas { get; set; }
    }
}
