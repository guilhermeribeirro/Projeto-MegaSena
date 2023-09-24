using System;
using System.ComponentModel.DataAnnotations;

public class DataCriacaoNaoAlteravelAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        DateTime dataCriacao = (DateTime)value;

        
        if (dataCriacao > DateTime.Now)
        {
            return new ValidationResult("A data de criação não pode ser no futuro.");
        }

        return ValidationResult.Success;
    }
}
