using ApiVelozesEAlugados.Application.ViewModel;
using PessoaNamespace;

namespace IPessoaRepositoryNameSpace
{
    public interface IPessoaRepository
    {
        void add(PessoaViewModel p);
        List<Pessoa> Get();
        PessoaViewModel GetByCpf(string cpf);
        Pessoa GetID(string email, string senha);
        void Update(string cpf, PessoaViewModel pessoa);
    }
}
