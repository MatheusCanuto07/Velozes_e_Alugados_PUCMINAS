using ApiVelozesEAlugados.Application.ViewModel;
using IPessoaRepositoryNameSpace;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using Org.BouncyCastle.Cms;
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

        public void add(PessoaViewModel pessoa)
        {
            Pessoa p = new Pessoa(pessoa);

            _Contexto.Pessoa.Add(p);
            _Contexto.SaveChanges();
        }
    }
}
