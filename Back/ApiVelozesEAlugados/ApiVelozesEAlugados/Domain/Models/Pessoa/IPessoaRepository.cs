using PessoaNamespace;

namespace IPessoaRepositoryNameSpace
{
    public interface IPessoaRepository
    {
        List<Pessoa> Get();
        Pessoa GetID(string email, string senha);
    }
}
