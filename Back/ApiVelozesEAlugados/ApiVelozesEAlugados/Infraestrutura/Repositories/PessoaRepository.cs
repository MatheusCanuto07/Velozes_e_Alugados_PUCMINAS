using IPessoaRepositoryNameSpace;
using Microsoft.EntityFrameworkCore;
using PessoaNamespace;

namespace ApiVelozesEAlugados.Infraestrutura.Repositories
{

    public class PessoaRepository : IPessoaRepository
    {
        private readonly ConnectionContext _Contexto = new ConnectionContext();

        public List<Pessoa> Get()
        {
            return _Contexto.pessoa.ToList();
        }

        public Pessoa GetID(string email, string senha)
        {
            throw new NotImplementedException();
        }
    }
}
