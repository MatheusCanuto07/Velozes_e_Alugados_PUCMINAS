using PessoaNamespace;
using IPessoaRepositoryNameSpace;
using Microsoft.AspNetCore.Mvc;
using ApiVelozesEAlugados.Domain.Models;
using ApiTeste.Application.ViewModel;
using ApiVelozesEAlugados.Application.ViewModel;

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

        [HttpPost]
        public IActionResult add(PessoaViewModel pessoa)
        {
            _pessoaRepositorio.add(pessoa);

            return Ok();
        }

        [HttpPut("{cpf}")]
        public IActionResult Put(string cpf, [FromBody] PessoaViewModel pessoaViewModel)
        {
            if (cpf != pessoaViewModel.CPF)
            {
                return BadRequest("CPF in URL does not match CPF in the body.");
            }

            var existingPessoa = _pessoaRepositorio.Get().FirstOrDefault(p => p.Cpf == cpf);

            if (existingPessoa == null)
            {
                return NotFound("Pessoa not found.");
            }

            _pessoaRepositorio.Update(cpf, pessoaViewModel);

            return Ok();
        }

        [HttpGet("{cpf}")]
        public IActionResult GetByCpf(string cpf)
        {
            var pessoa = _pessoaRepositorio.GetByCpf(cpf);

            if (pessoa == null)
            {
                return NotFound("Pessoa not found.");
            }

            return Ok(pessoa);
        }
    } 
}
