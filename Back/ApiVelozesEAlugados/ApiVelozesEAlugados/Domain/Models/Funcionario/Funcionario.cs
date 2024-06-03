using System;
using System.Collections.Generic;
using ApiVelozesEAlugados.Domain.Models.Relacoes;
using Relacoes;
using PessoaNamespace;

namespace FuncionarioNameSpace;

public partial class Funcionario
{
    public int Matricula { get; set; }

    public string PessoaCpf { get; set; } = null!;

    public string? Cargo { get; set; }

    public virtual ICollection<Alteracao> Alteracao { get; set; } = new List<Alteracao>();

    public virtual Pessoa PessoaCpfNavigation { get; set; } = null!;
}
