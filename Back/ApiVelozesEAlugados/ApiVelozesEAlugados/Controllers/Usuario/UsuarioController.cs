using ApiVelozesEAlugados.Domain.Models.UsuarioRe;
using IPessoaRepositoryNameSpace;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiVelozesEAlugados.Controllers.Usuario
{
    [ApiController]
    [Route("/login")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepositorio;

        public UsuarioController(IUsuarioRepository usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio ?? throw new ArgumentNullException(nameof(usuarioRepositorio));
        }

        //[HttpGet]
        //public IActionResult Get()
        //{
        //    var pessoa = _usuarioRepositorio.Get();

        //    return Ok(pessoa);
        //}

        [HttpGet]
        [Route("validarLogin/{email}/{senha}")]
        public IActionResult ValidaLogin(string email, string senha)
        {
            var usuario = _usuarioRepositorio.GetAll()
                                  .FirstOrDefault(u => u.Email == email && u.Senha == senha);

            if (usuario == null)
            {
                return Unauthorized("Email ou senha incorretos.");
            }

            return Ok(usuario);
        }
    }
}
