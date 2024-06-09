using Microsoft.VisualBasic;
using PessoaNamespace;
using UsuarioName;

namespace ApiVelozesEAlugados.Application.ViewModel
{
    public class PessoaViewModel
    {
        public PessoaViewModel(Usuario u, Pessoa p)
        {
            this.CPF = p.Cpf;
            this.NOME_PESSOA = p.NomePessoa;
            this.DATA_NASCIMENTO = p.DataNascimento;
            this.CNH_PESSOA = p.CnhPessoa;
            this.CEP_PESSOA = p.CepPessoa;
            this.LOGRADOURO = p.Logradouro;
            this.NUMERO = p.Numero;
            this.COMPLEMENTO = p.Complemento;
            this.BAIRRO = p.Bairro;
            this.CIDADE = p.Cidade;
            this.UF = p.Uf;
            this.SEXO = p.Sexo;
            this.TIPO = u.Tipo;
            this.Email = u.Email;
            this.Senha = u.Senha;
        }

        public PessoaViewModel() { }

        public string CPF { get; set; }
        public string? NOME_PESSOA { get; set; }
        public DateTime? DATA_NASCIMENTO { get; set; }
        public string? CNH_PESSOA { get; set; }
        public string? CEP_PESSOA { get; set; }
        public string? LOGRADOURO { get; set; }
        public string? NUMERO { get; set; }
        public string? COMPLEMENTO { get; set; }
        public string? BAIRRO { get; set; }
        public string? CIDADE { get; set; }
        public string? UF { get; set; }
        public string? SEXO { get; set; }
        public string? TIPO { get; set;}
        public string? Email { get; set; }
        public string? Senha { get; set; }
    }
}
