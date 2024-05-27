using System;
using System.Collections.Generic;

namespace ApiVelozesEAlugados.db;

public partial class Telefones
{
    public string PessoaCpf1 { get; set; } = null!;

    public string NumTelefone { get; set; } = null!;

    public virtual Pessoa PessoaCpf1Navigation { get; set; } = null!;
}
