using Microsoft.AspNetCore.Mvc;
using Projeto_MegaSena.Models.Request;
using Projeto_MegaSena.Models.Response;

namespace Projeto_MegaSena.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class TesteController : ControllerBase
    {

        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Ola´minha primeira requisao get");
        }
        [HttpGet("Obter Por ID/{id}")]

        public IActionResult Get (int id)
        {

            return Ok($"Olá mundo, exemplo rota id = {id}");
        }

        [HttpPost]
        public IActionResult Post(TesteViewModel testeViewModel)
        {
            if (testeViewModel.CPF < 11)
            {
                return BadRequest(new NovoTesteCriadoResponse()
                {
                    sucesso = false,
                    mensagem = "Não existe CPF menor que 11 numeros"
                });
            }

            
            return Ok(new NovoTesteCriadoResponse()
            {
                sucesso = true,
                mensagem = "Teste criado com sucesso"
            });
        }

    }
}
