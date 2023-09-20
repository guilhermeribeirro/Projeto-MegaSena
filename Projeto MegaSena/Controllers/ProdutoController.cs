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
    public class ProdutoController : PrincipalController
    {
        private readonly string _jogoCaminhoArquivo;

        public ProdutoController()

        {
            _jogoCaminhoArquivo = Path.Combine(Directory.GetCurrentDirectory(), "Data", "jogosMega.json");




        }

        #region Metodos do arquivo


        private List<ProdutoViewModel>LerProdutosDoArquivo()
        {
            if (!System.IO.File.Exists(_jogoCaminhoArquivo))
            {
                        return new List<ProdutoViewModel>();


            }

            string json = System.IO.File.ReadAllText(_jogoCaminhoArquivo);

            return JsonConvert.DeserializeObject<List<ProdutoViewModel>>(json);

        }

        private int ObterProximoCodigoDisponivel()
        {
            List<ProdutoViewModel> jogos = LerProdutosDoArquivo();

            if (jogos.Any())
            {

                return jogos.Max(p => p.CodigoJogo) + 1;

            }
            else
            {

                return 1;
            }

        }

        private void EscreverProdutosNoArquivo(List<ProdutoViewModel>jogos)


        {
            string json = JsonConvert.SerializeObject(jogos);

            System.IO.File.WriteAllText(_jogoCaminhoArquivo, json);


        }


        #endregion

        #region Operacoes CRUD

        [HttpGet]

        public IActionResult Get()
        {
            List<ProdutoViewModel> jogos = LerProdutosDoArquivo();
            return Ok(jogos);
        }

        [HttpGet("{codigojogo}")]

        public IActionResult Get(int codigo)

        {
            List<ProdutoViewModel> jogos = LerProdutosDoArquivo();
            ProdutoViewModel jogo = jogos.Find(p => p.CodigoJogo == codigo);

            if (jogos == null)
            {

                return NotFound();
            }
            return Ok(jogos);

        }

        [HttpPost]

        public IActionResult Post([FromBody] NovoProdutoViewModel jogo)
        {
            if (!ModelState.IsValid)



                return ApiBadRequestResponse(ModelState);

            List<ProdutoViewModel> jogos = LerProdutosDoArquivo();
            int proximoCodigo = ObterProximoCodigoDisponivel();

            ProdutoViewModel novoJogo = new ProdutoViewModel()
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

                DataJogo = jogo.DataJogo,

                






            };

            jogos.Add(novoJogo);
            EscreverProdutosNoArquivo(jogos);

            return ApiResponse(novoJogo, "Jogo Registrado com sucesso!");






        }
        [HttpPut("{codigojogo}")]

        public IActionResult Put (int codigo, [FromBody] EditarProdutoViewModel jogo)
        {
            if (jogo == null)
                return BadRequest();

            List<ProdutoViewModel> jogos = LerProdutosDoArquivo();

            int index = jogos.FindIndex(p => p.CodigoJogo == codigo);

            if (index == -1)

                return NotFound();

            ProdutoViewModel jogoEditado = new ProdutoViewModel()

            {
                CodigoJogo = codigo,

                Nome = jogo.Nome,

                CPF = jogo.CPF,

                PrimeiroNumero = jogo.PrimeiroNumero,

                SegundoNumero = jogo.SegundoNumero,

                TerceiroNumero = jogo.TerceiroNumero,

                QuartoNumero = jogo.QuartoNumero,

                QuintoNumero = jogo.QuintoNumero,

                SextoNumero = jogo.SextoNumero

            };

            jogos[index] = jogoEditado;

            EscreverProdutosNoArquivo(jogos);

            return NoContent();

        }

        [HttpDelete("{codigojogo}")]

        public IActionResult Delete(int codigo)
        {
            List<ProdutoViewModel> jogos = LerProdutosDoArquivo();

            ProdutoViewModel jogo = jogos.Find(p => p.CodigoJogo == codigo);
            if (jogo == null)

                return NotFound();

            jogos.Remove(jogo);
            EscreverProdutosNoArquivo(jogos);

            return NoContent();


        }
        #endregion




    }
}
