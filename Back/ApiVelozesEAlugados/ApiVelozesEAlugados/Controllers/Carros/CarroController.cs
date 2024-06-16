using ApiVelozesEAlugados.Application.ViewModel;
using Microsoft.AspNetCore.Mvc;
using CarroName;
using ApiVelozesEAlugados.Domain.Models;
using ICarroRepositoryNameSpace;
using AlugaDevolveNameSpace;


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

            var carro = _carroRepository.Get();

            return Ok(carro);
        }

        [HttpPost]
        public IActionResult add(CarroViewModel carroViewModel) { 
            
            _carroRepository.add(carroViewModel);

            return Ok();

        }

        [HttpPut]
        public IActionResult Put([FromBody] CarroViewModel carroViewModel) {

            var existeCarro = _carroRepository.Get().FirstOrDefault(c => c.Placa == carroViewModel.Placa);
            if (existeCarro == null) { 
                
                return NotFound("Viéculo não encontrado.");

           }

            _carroRepository.Update(carroViewModel);

            return Ok();

        }

        [HttpGet]
        [Route("{placa}")]
        public IActionResult GetByPlaca(string placa) { 
            
            var carro = _carroRepository.GetByPlaca(placa);

            if (carro == null) {
                return NotFound("Veículo não encontrado.");
            }

            return Ok(carro);
        }

        [HttpDelete]
        [Route("{placa}")]
        public IActionResult deleteCarro(string placa)
        {

            
            _carroRepository.delete(placa);

            return Ok("Carro deletado com sucesso");
        }

        [HttpPost]
        [Route("/Alugar")]
        public IActionResult alugarCarro(AlugaDevolveViewModel a)
        {
            _carroRepository.AlugarCarro(a);
            return Ok("Aluguel realizado com sucesso!");
        }

    }
}
