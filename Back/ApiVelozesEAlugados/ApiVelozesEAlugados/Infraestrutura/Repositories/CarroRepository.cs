using AlugaDevolveNameSpace;
using ApiVelozesEAlugados.Application.ViewModel;
using ApiVelozesEAlugados.Domain.Models;
using CarroName;
using ICarroRepositoryNameSpace;
using Microsoft.EntityFrameworkCore;

namespace ApiVelozesEAlugados.Infraestrutura.Repositories
{
    public class CarroRepository : ICarroRepository
    {
        private readonly ConnectionContext _Contexto = new ConnectionContext();

        public void add(CarroViewModel carro)
        {
            Carro c = new Carro(carro);

            _Contexto.Add(c);

            _Contexto.SaveChanges();

        }

        public void AlugarCarro(AlugaDevolveViewModel Alugar)
        {
            var carroAlugado = _Contexto.Carro.FirstOrDefault(c => c.Placa == Alugar.Carro_placa);

            if (carroAlugado == null) {
                throw new Exception("Carro não encontrado.");
            }

            carroAlugado.Disponibilidade = 0;            

            AlugaDevolve alugaDevolve = new AlugaDevolve(Alugar);

            _Contexto.Carro.Update(carroAlugado);
            _Contexto.AlugaDevolve.Add(alugaDevolve);
            _Contexto.SaveChanges();
        }

        public void delete(string placa)
        {
            var existeCarro = _Contexto.Carro.Include(c => c.AlugaDevolve).FirstOrDefault(c => c.Placa == placa);

            if (existeCarro == null)
            {
                throw new Exception("Carro não encontrado.");
            }
            _Contexto.AlugaDevolve.RemoveRange(existeCarro.AlugaDevolve);
            _Contexto.Carro.Remove(existeCarro);
            _Contexto.SaveChanges();
        }

        public List<Carro> Get()
        {
            return _Contexto.Carro.ToList();
        }

        public Carro GetByPlaca(string _placa)
        {
            return _Contexto.Carro.FirstOrDefault(c => c.Placa == _placa);

        }

        public void Update(CarroViewModel carroViewModel)
        {
            var existeCarro = _Contexto.Carro.FirstOrDefault(c=> c.Placa == carroViewModel.Placa);

            if (existeCarro == null)
            {
                throw new Exception("Carro não encontrado.");
            }

            existeCarro.Modelo = carroViewModel.Modelo;
            existeCarro.Marca = carroViewModel.Marca;
            existeCarro.Cor = carroViewModel.Cor;   
            existeCarro.Ano = carroViewModel.Ano;
            existeCarro.Km = carroViewModel.Km;
            existeCarro.Disponibilidade = carroViewModel?.Disponibilidade;
            existeCarro.PrecoKm = carroViewModel?.PrecoKm;
            existeCarro.PrecoDiaria = carroViewModel?.PrecoDiaria;
            existeCarro.Observacoes = carroViewModel?.Observacoes;

            _Contexto.Carro.Update(existeCarro);
            _Contexto.SaveChanges();
        }
    }
}
