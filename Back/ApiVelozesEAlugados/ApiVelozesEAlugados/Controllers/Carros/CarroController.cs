using ApiVelozesEAlugados.Application.ViewModel;
using Microsoft.AspNetCore.Mvc;
using CarroName;
using ApiVelozesEAlugados.Domain.Models;
using ICarroRepositoryNameSpace;


namespace ApiVelozesEAlugados.Controllers.Carros
{
    [ApiController]
    [Route("api/Carro")]
    public class CarroController : ControllerBase
    {
        private readonly ICarroRepository _carroRepository;

        public CarroController(ICarroRepository carroRepository)
        {
            _carroRepository = carroRepository;
        }

        [HttpGet]
        public IActionResult Get() {

            var carro = _carroRepository.Get(); ;

            return Ok(carro);
        }

        [HttpPost]
        public IActionResult add(CarroViewModel carroViewModel) { 
            
            _carroRepository.add(carroViewModel);

            return Ok();

        }

        [HttpPut("{placa}")]
        public IActionResult Put(string _placa, [FromBody] CarroViewModel carroViewModel) {

            if (_placa != carroViewModel.Placa) {

                return BadRequest("Placa informada não existe na base de dados.");
            }

            var existeCarro = _carroRepository.Get().FirstOrDefault(c => c.Placa == _placa);
            if (existeCarro == null) { 
                
                return NotFound("Viéculo não encontrado.");

           }

            _carroRepository.Update(_placa, carroViewModel);

            return Ok();

        }

        [HttpGet("{placa}")]
        public IActionResult GetByPlaca(string _placa) { 
            
            var carro = _carroRepository.GetByPlaca(_placa);

            if (carro == null) {

                return NotFound("Veículo não encontrado.");
            }

            return Ok(carro);
        }
    }
}
