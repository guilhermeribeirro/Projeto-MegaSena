using Projeto_MegaSena.Models.Request;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

[AttributeUsage(AttributeTargets.Class)]
public class NumerosDiferentesAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        var instance = validationContext.ObjectInstance as NovoProdutoViewModel;

        if (instance != null)
        {
            var numeros = new List<int>
            {
                instance.PrimeiroNumero,
                instance.SegundoNumero,
                instance.TerceiroNumero,
                instance.QuartoNumero,
                instance.QuintoNumero,
                instance.SextoNumero
            };

            if (numeros.Distinct().Count() != numeros.Count())
            {
                return new ValidationResult("Os números não devem ser iguais.");
            }
        }

        return ValidationResult.Success;
    }
}

