using ApiVelozesEAlugados.Application.ViewModel;
using  CarroName;


namespace ICarroRepositoryNameSpace
{
    public interface ICarroRepository
    {
        void add(CarroViewModel carro);
        List<Carro> Get();

        Carro GetByPlaca(string placa);
        

        void Update(string placa, CarroViewModel carro);
    }
}

