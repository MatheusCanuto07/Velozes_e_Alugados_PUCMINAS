using ApiTeste.Application.Services;
using ApiTeste.Application.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ApiTeste.Controllers
{
    [ApiController]
    [Route("api/v1/auth")]
    public class AuthController : Controller
    {
        [HttpPost]
        public IActionResult Auth(string username, string password)
        {
            if (username == "Matheus" && password == "719821")
            {
                var token = TokenService.GenerateToken(new Domain.Models.Funcionario.Funcionario());
                return Ok(token);
            }

            return BadRequest("Username or password invalid;");
        }
    }
}
