using System;
using System.Collections.Generic;

namespace ApiVelozesEAlugados.db;

public partial class Funcionario
{
    public int Matricula { get; set; }

    public string PessoaCpf { get; set; } = null!;

    public string? Cargo { get; set; }

    public virtual ICollection<Alteracao> Alteracao { get; set; } = new List<Alteracao>();

    public virtual Pessoa PessoaCpfNavigation { get; set; } = null!;
}
