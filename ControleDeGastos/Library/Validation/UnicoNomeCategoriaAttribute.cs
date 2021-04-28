using ControleDeGastos.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ControleDeGastos.Library.Validation
{
    public class UnicoNomeCategoriaAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            Categoria categoria = validationContext.ObjectInstance as Categoria;

            var _db = (ControleDeGastosContext)validationContext.GetService(typeof(ControleDeGastosContext));

            //Verificar se já existe no BD um registro que tenha o mesmo nome.
            // - Verificar se o nome ja existe
            // - Verificar se o id é o mesmo

            var palavraBanco = _db.Categoria.Where(a => a.Nome == categoria.Nome && a.Id != categoria.Id).FirstOrDefault();

            if (palavraBanco == null)
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult("A categoria '" + categoria.Nome + "' já existe!");
            }

        }
    }
}
