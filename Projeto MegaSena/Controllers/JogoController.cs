using Gherkin.Ast;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Projeto_MegaSena.Models.Request;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json.Serialization;

namespace Projeto_MegaSena.Controllers
{

    [Route("api/[controller]")]

    [ApiController]
    public class JogoController : PrincipalController
    {
        private readonly string _jogoCaminhoArquivo;

        public JogoController()

        {
            _jogoCaminhoArquivo = Path.Combine(Directory.GetCurrentDirectory(), "Data", "jogosMega.json");




        }

        #region Metodos do arquivo


        private List<JogoViewModel> LerJogos()
        {
            if (!System.IO.File.Exists(_jogoCaminhoArquivo))
            {
                        return new List<JogoViewModel>();


            }

            string json = System.IO.File.ReadAllText(_jogoCaminhoArquivo);

            return JsonConvert.DeserializeObject<List<JogoViewModel>>(json);

        }

        private int ObterProximoCodigoDisponivel()
        {
            List<JogoViewModel> jogos = LerJogos();

            if (jogos.Any())
            {

                return jogos.Max(p => p.CodigoJogo) + 1;

            }
            else
            {

                return 1;
            }

        }

        private void EscreverApostasNoArquivo(List<JogoViewModel>jogos)


        {
            string json = JsonConvert.SerializeObject(jogos);

            System.IO.File.WriteAllText(_jogoCaminhoArquivo, json);


        }


        #endregion

        #region Operacoes CRUD

        [HttpGet]

        public IActionResult Get()
        {
            List<JogoViewModel> jogos = LerJogos();
            return Ok(jogos);
        }

       

        

        [HttpPost]

        public IActionResult Post([FromBody] NovoJogoViewModel jogo)
        {
            if (!ModelState.IsValid)



                return ApiBadRequestResponse(ModelState);

            List<JogoViewModel> jogos = LerJogos();
            int proximoCodigo = ObterProximoCodigoDisponivel();

            JogoViewModel novoJogo = new JogoViewModel()
            {
                CodigoJogo = proximoCodigo,

                Nome = jogo.Nome,

                CPF = jogo.CPF,

                PrimeiroNumero = jogo.PrimeiroNumero,

                SegundoNumero = jogo.SegundoNumero,

                TerceiroNumero = jogo.TerceiroNumero,

                QuartoNumero = jogo.QuartoNumero,

                QuintoNumero = jogo.QuintoNumero,

                SextoNumero = jogo.SextoNumero,

                

                






            };

            jogos.Add(novoJogo);
            EscreverApostasNoArquivo(jogos);

            return ApiResponse(novoJogo, "Jogo Registrado com sucesso!");






        }



        
  




        #endregion




    }
}
