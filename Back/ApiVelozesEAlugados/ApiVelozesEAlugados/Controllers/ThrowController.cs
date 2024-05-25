using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace ApiTeste.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ThrowController : ControllerBase
    {
        //Caso de erro em ambiente de produção o erro não vai ser mostrado com todos os detalhes
        [Route("/error")]
        public IActionResult HandleError() =>
            Problem();
        
        [Route("/error-development")]
        public IActionResult HandleErrorDevelopment(
        [FromServices] IHostEnvironment hostEnvironment)
        {
            if (!hostEnvironment.IsDevelopment())
            {
                return NotFound();
            }

            var exceptionHandlerFeature =
                HttpContext.Features.Get<IExceptionHandlerFeature>()!;

            return Problem(
                detail: exceptionHandlerFeature.Error.StackTrace,
                title: exceptionHandlerFeature.Error.Message);
        }
    }
}
