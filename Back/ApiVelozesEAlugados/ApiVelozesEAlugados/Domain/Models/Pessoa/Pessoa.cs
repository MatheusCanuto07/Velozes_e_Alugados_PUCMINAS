using System;
using System.Collections.Generic;
using Telefone;
using ClienteName;
using FuncionarioNameSpace;
using UsuarioName;
using ApiVelozesEAlugados.Application.ViewModel;
using Microsoft.VisualBasic;

namespace PessoaNamespace;

public class Pessoa
{
    public Pessoa()
    {

    }
    public Pessoa(PessoaViewModel pvm)
    {
        this.Cpf = pvm.CPF;
        this.NomePessoa = pvm.NOME_PESSOA;
        this.DataNascimento = pvm.DATA_NASCIMENTO;
        this.CnhPessoa = pvm.CNH_PESSOA;
        this.CepPessoa = pvm.CEP_PESSOA;
        this.Logradouro = pvm.LOGRADOURO;
        this.Numero = pvm.NUMERO;
        this.Complemento = pvm.COMPLEMENTO;
        this.Bairro = pvm.BAIRRO;
        this.Cidade = pvm.CIDADE;
        this.Uf = pvm.UF;
        this.Sexo = pvm.SEXO;
    }

    public string Cpf { get; set; } = null!;

    public string? NomePessoa { get; set; }

    public DateTime? DataNascimento { get; set; }

    public string? CnhPessoa { get; set; }

    public string? CepPessoa { get; set; }

    public string? Logradouro { get; set; }

    public string? Numero { get; set; }

    public string? Complemento { get; set; }

    public string? Bairro { get; set; }

    public string? Cidade { get; set; }

    public string? Uf { get; set; }

    public string? Sexo { get; set; }

    public virtual Cliente? Cliente { get; set; }

    public virtual ICollection<Funcionario> Funcionario { get; set; } = new List<Funcionario>();

    public virtual ICollection<Telefones> Telefones { get; set; } = new List<Telefones>();

    public virtual ICollection<Usuario> Usuario { get; set; } = new List<Usuario>();
}
