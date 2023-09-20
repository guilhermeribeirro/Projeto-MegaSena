using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Projeto_MegaSena.Configuration;
using TechTalk.SpecFlow.CommonModels;

namespace Projeto_MegaSena.Controllers
{
    public abstract class PrincipalController : ControllerBase
    {
        protected IActionResult ApiResponse<T>(T data, string message = null)
        {
            var response = new ApiResponse<T>
            {

                Success = true,

                Message = message,

                Data = data
            };
            return Ok(response);

        }

        protected IActionResult ApiBadRequestResponse(ModelStateDictionary modelState, string message = "Dados inválidos")
        {

            var erros = modelState.Values.SelectMany(e => e.Errors);

            var response = new ApiResponse<object>
            {

                Success = false,

                Message = message,

                Data = erros.Select(n => n.ErrorMessage).ToArray()
            };
            return BadRequest(response);
        }


    }
}
