using ApiVelozesEAlugados.Domain.Models.UsuarioRe;
using IPessoaRepositoryNameSpace;
using Microsoft.EntityFrameworkCore;
using PessoaNamespace;
using UsuarioName;

namespace ApiVelozesEAlugados.Infraestrutura.Repositories
{

    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly ConnectionContext _Contexto = new ConnectionContext();

        public List<Usuario> GetAll()
        {
            return _Contexto.Usuario.ToList();
        }
        
        public bool ValidaLogin(string email, string senha)
        {
            throw new NotImplementedException();
        }

        public Pessoa GetID(string email, string senha)
        {
            throw new NotImplementedException();
        }

    }
}
