using System.ComponentModel.DataAnnotations;
using System;
using Microsoft.AspNetCore.Identity;

namespace Projeto_MegaSena.Models.Validations
{
    public class CpfValidationAtributte : ValidationAttribute

    {
            protected override ValidationResult IsValid(object value, ValidationContext validationcontext)
        {
            if (value == null)
            {
                return ValidationResult.Success; 
            }

            string cpf = value.ToString().Replace(".", "").Replace("-", ""); 

            if (!IsDigitsOnly(cpf) || cpf.Length != 11)
            {
                return new ValidationResult("O CPF deve conter exatamente 11 dígitos numéricos.");
            }

            
            if (IsRepeatingDigits(cpf))
            {
                return new ValidationResult("O CPF não pode ter todos os dígitos iguais.");
            }

            
            int sum = 0;
            for (int i = 0; i < 9; i++)
            {
                sum += int.Parse(cpf[i].ToString()) * (10 - i);
            }

            int remainder = sum % 11;
            int firstVerifier = remainder < 2 ? 0 : 11 - remainder;

            if (int.Parse(cpf[9].ToString()) != firstVerifier)
            {
                return new ValidationResult("O CPF informado não é válido.");
            }

            sum = 0;
            for (int i = 0; i < 10; i++)
            {
                sum += int.Parse(cpf[i].ToString()) * (11 - i);
            }

            remainder = sum % 11;
            int secondVerifier = remainder < 2 ? 0 : 11 - remainder;

            if (int.Parse(cpf[10].ToString()) != secondVerifier)
            {
                return new ValidationResult("O CPF informado não é válido.");
            }

            return ValidationResult.Success;
        }

        private bool IsDigitsOnly(string value)
        {
            foreach (char c in value)
            {
                if (!char.IsDigit(c))
                {
                    return false;
                }
            }
            return true;
        }

        private bool IsRepeatingDigits(string value)
        {
            char firstChar = value[0];
            foreach (char c in value)
            {
                if (c != firstChar)
                {
                    return false;
                }
            }
            return true;
        }
    }


}
   