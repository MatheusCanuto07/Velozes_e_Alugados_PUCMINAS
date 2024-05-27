using ApiTeste.Infraestrutura.Repositories;
using ApiVelozesEAlugados.db;

namespace ApiVelozesEAlugados.Infraestrutura.Repositories
{
    public class PessoaRepositorio : IPessoaRepositorio
    {
        private readonly ConnectionContext _Contexto = new ConnectionContext();
        public List<Pessoa> Get()
        {
            return _Contexto.pessoa.ToList();
        }
    }
}
