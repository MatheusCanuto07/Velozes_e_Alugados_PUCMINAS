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

        public void Update(string cpf, PessoaViewModel pessoaViewModel)
        {
            var existingPessoa = _Contexto.Pessoa.FirstOrDefault(p => p.Cpf == cpf);

            if (existingPessoa == null)
            {
                throw new Exception("Pessoa not found.");
            }

            existingPessoa.NomePessoa = pessoaViewModel.NOME_PESSOA;
            existingPessoa.DataNascimento = pessoaViewModel.DATA_NASCIMENTO;
            existingPessoa.CnhPessoa = pessoaViewModel.CNH_PESSOA;
            existingPessoa.CepPessoa = pessoaViewModel.CEP_PESSOA;
            existingPessoa.Logradouro = pessoaViewModel.LOGRADOURO;
            existingPessoa.Numero = pessoaViewModel.NUMERO;
            existingPessoa.Complemento = pessoaViewModel.COMPLEMENTO;
            existingPessoa.Bairro = pessoaViewModel.BAIRRO;
            existingPessoa.Cidade = pessoaViewModel.CIDADE;
            existingPessoa.Uf = pessoaViewModel.UF;
            existingPessoa.Sexo = pessoaViewModel.SEXO;

            _Contexto.Pessoa.Update(existingPessoa);
            _Contexto.SaveChanges();
        }

        public Pessoa GetByCpf(string cpf)
        {
            return _Contexto.Pessoa.FirstOrDefault(p => p.Cpf == cpf);
        }


    }
}
