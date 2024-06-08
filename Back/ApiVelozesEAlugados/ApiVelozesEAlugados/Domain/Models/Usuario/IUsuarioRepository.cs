using PessoaNamespace;
using UsuarioName;

namespace ApiVelozesEAlugados.Domain.Models.UsuarioRe
{
    public interface IUsuarioRepository
    {
        List<Usuario> GetAll();
        bool ValidaLogin(string email, string senha);
    }
}
