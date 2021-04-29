using ControleDeGastos.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ControleDeGastos.Library.Validation
{
    public class UnicoNomeTipoConta : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            TipoConta tipoConta = validationContext.ObjectInstance as TipoConta;

            var _db = (ControleDeGastosContext)validationContext.GetService(typeof(ControleDeGastosContext));

            //Verificar se já existe no BD um registro que tenha o mesmo nome.
            // - Verificar se o nome ja existe
            // - Verificar se o id é o mesmo

            var palavraBanco = _db.TipoConta.Where(a => a.Nome == tipoConta.Nome && a.Id != tipoConta.Id).FirstOrDefault();

            if (palavraBanco == null)
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult("O tipo de conta '" + tipoConta.Nome + "' já existe!");
            }

        }
    }
}
