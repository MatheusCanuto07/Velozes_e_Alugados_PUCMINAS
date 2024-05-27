using ApiVelozesEAlugados.db;
using Microsoft.AspNetCore.Mvc;

namespace ApiVelozesEAlugados.Controllers
{
    [ApiController]
    [Route("api/pessoa")]
    public class PessoaController : ControllerBase
    {
        private readonly IPessoaRepositorio _pessoaRepositorio;

        public PessoaController(IPessoaRepositorio pessoaRepositorio)
        {
            _pessoaRepositorio = pessoaRepositorio ?? throw new ArgumentNullException(nameof(pessoaRepositorio));
        }

        [HttpGet]
        public IActionResult Get()
        {
            var pessoa = _pessoaRepositorio.Get();

            return Ok(pessoa);
        }
    }
}
