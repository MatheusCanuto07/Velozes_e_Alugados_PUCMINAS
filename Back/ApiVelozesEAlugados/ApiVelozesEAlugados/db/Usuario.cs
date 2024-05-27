using System;
using System.Collections.Generic;

namespace ApiVelozesEAlugados.db;

public partial class Usuario
{
    public string Email { get; set; } = null!;

    public string? Senha { get; set; }

    public string PessoaCpf { get; set; } = null!;

    public virtual Pessoa PessoaCpfNavigation { get; set; } = null!;
}
