using ApiTeste.Application.ViewModel;
using ApiTeste.Domain.DTOs;
using ApiTeste.Domain.Models.Funcionario;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiTeste.Controllers
{
    [ApiController]
    [Route("api/v1/funcionario")]
    public class FuncionarioController : ControllerBase
    {
        private readonly IFuncionariorepository _funcionarioRep;
        private readonly ILogger<FuncionarioController> _logger;
        private readonly IMapper _mapper;

        public FuncionarioController(IFuncionariorepository funcionarioRep, ILogger<FuncionarioController> logger, IMapper mapper)
        {
            _funcionarioRep = funcionarioRep ?? throw new ArgumentNullException(nameof(funcionarioRep));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [Authorize]
        [HttpPost]
        public IActionResult Add([FromForm] FuncionarioViewModel funcionarioView)
        {
            var filePath = Path.Combine("Storage", funcionarioView.foto.FileName);

            var funcionario = new Funcionario(funcionarioView.nome, funcionarioView.idade, filePath);

            using Stream fileStream = new FileStream(filePath, FileMode.Create);

            funcionarioView.foto.CopyTo(fileStream);

            _funcionarioRep.Add(funcionario);
            return Ok();
        }
        [Authorize]
        [HttpPost]
        [Route("{id}/download")]
        public IActionResult downloadFoto(int id)
        {
            var fun = _funcionarioRep.Get(id);

            var dataBytes = System.IO.File.ReadAllBytes(fun.foto);

            return File(dataBytes, "image/jpg");
        }
        [HttpGet]
        public IActionResult Get(int pageNumber, int pageQuantity)
        {
            _logger.Log(LogLevel.Error, "Teve um erro");
            var funcionario = _funcionarioRep.get(pageNumber, pageQuantity);
            //throw new Exception("Erro de teste");
            _logger.LogInformation("Teste");
            return Ok(funcionario);
        }
        [HttpGet]
        [Route("{id}")]
        public IActionResult Search(int id)
        {
            var funcionario = _funcionarioRep.Get(id);
            var funcionarioDTO = _mapper.Map<FuncionarioDTO>(funcionario);
            return Ok(funcionarioDTO);
        }
    }
}
