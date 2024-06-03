using PessoaNamespace;
using IPessoaRepositoryNameSpace;
using Microsoft.AspNetCore.Mvc;

namespace ApiVelozesEAlugados.Controllers.Pessoa
{
    [ApiController]
    [Route("api/pessoa")]
    public class PessoaController : ControllerBase
    {
        private readonly IPessoaRepository _pessoaRepositorio;

        public PessoaController(IPessoaRepository pessoaRepositorio)
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
