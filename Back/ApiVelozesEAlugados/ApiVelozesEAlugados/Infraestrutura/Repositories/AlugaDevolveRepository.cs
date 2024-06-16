using ApiVelozesEAlugados.Domain.Models.Relacoes;
using ICarroRepositoryNameSpace;

namespace ApiVelozesEAlugados.Infraestrutura.Repositories
{
    public class AlugaDevolveRepository : IAlugaDevolve
    {
        private readonly ConnectionContext _Contexto = new ConnectionContext();

        public List<AlugaDevolve> Get()
        {
            return _Contexto.AlugaDevolve.ToList();
        }
    }
}
