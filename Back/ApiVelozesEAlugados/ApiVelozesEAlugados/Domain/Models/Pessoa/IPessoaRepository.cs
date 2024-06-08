using ApiVelozesEAlugados.Application.ViewModel;
using PessoaNamespace;

namespace IPessoaRepositoryNameSpace
{
    public interface IPessoaRepository
    {
        void add(PessoaViewModel pessoa);
        List<Pessoa> Get();

        Pessoa GetByCpf(string cpf);
        Pessoa GetID(string email, string senha);

        void Update(string cpf, PessoaViewModel pessoa);
    }
}
