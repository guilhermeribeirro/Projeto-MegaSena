﻿namespace Projeto_MegaSena.Models.Request
{
    public class JogoViewModel
    {
        public int CodigoJogo { get; set; }


        public string Nome { get; set; }

        public string CPF { get; set; }

        public int PrimeiroNumero { get; set; }


        public int SegundoNumero { get; set; }

        public int TerceiroNumero { get; set; }


        public int QuartoNumero { get; set; }


        public int QuintoNumero { get; set; }


        public int SextoNumero { get; set; }

        public DateTime DataJogo { get; set; }

        public JogoViewModel()
        {

            DataJogo = DateTime.Now;
        }
    }
}
