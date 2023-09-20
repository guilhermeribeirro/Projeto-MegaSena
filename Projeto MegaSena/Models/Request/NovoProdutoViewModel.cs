using Microsoft.AspNetCore.Mvc;
using Projeto_MegaSena.Models.Validations;
using System.ComponentModel.DataAnnotations;

namespace Projeto_MegaSena.Models.Request

{
    [NumerosDiferentes(ErrorMessage = "Os números não devem ser iguais.")]
    public class NovoProdutoViewModel 
    {


        [Required(ErrorMessage = "O nome é obrigatório!")]
        [StringLength(255, MinimumLength = 1, ErrorMessage = "O nome deve ter entre 1 e 255 caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "o CPF é obrigatório!")]
        [CpfValidationAtributte(ErrorMessage = "o CPF está inválido")]
        public string CPF { get; set; }

        [Range(1, 60, ErrorMessage = "O número deve estar entre 1 e 60")]
        [Required(ErrorMessage = "o Primeiro Número  é obrigatório!")]
        public int PrimeiroNumero { get; set; }

        [Range(1, 60, ErrorMessage = "O número deve estar entre 1 e 60")]
        [Required(ErrorMessage = "o Segundo Número é obrigatório!")]
        
        public int SegundoNumero { get; set; }

        [Range(1, 60, ErrorMessage = "O número deve estar entre 1 e 60")]
        [Required(ErrorMessage = "o Terceiro Número é obrigatório!")]
        
        public int TerceiroNumero { get; set; }

        [Range(1, 60, ErrorMessage = "O número deve estar entre 1 e 60")]
        [Required(ErrorMessage = "o Quarto Número é obrigatório!")]
        
        public int QuartoNumero { get; set; }

        [Range(1, 60, ErrorMessage = "O número deve estar entre 1 e 60")]
        [Required(ErrorMessage = "o Quinto Número é obrigatório!")]
        
        public int QuintoNumero { get; set; }

        [Range(1, 60, ErrorMessage = "O número deve estar entre 1 e 60")]
        [Required(ErrorMessage = "o Sexto Número é obrigatório!")]
        
        public int SextoNumero { get; set; }

        public DateTime DataJogo { get; set; }


    }



}
