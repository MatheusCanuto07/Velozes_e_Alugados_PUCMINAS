using ApiVelozesEAlugados.Application.ViewModel;
using CarroName;

namespace ApiVelozesEAlugados.Domain.Models.Relacoes
{
    public interface IAlugaDevolve
    {
        void add(AlugaDevolveViewModel alugadevolve);
        List<AlugaDevolve> Get();

        Carro GetByCod(int codlocacao);


        void Update(int codlocacao, AlugaDevolveViewModel alugadevolve);
    }
}
