using System;
using System.Collections.Generic;

namespace ApiVelozesEAlugados.db;

public partial class Cliente
{
    public string PessoaCpf { get; set; } = null!;

    public string? TipoCliente { get; set; }

    public string? CnpjCliente { get; set; }

    public virtual ICollection<AlugaDevolve> AlugaDevolve { get; set; } = new List<AlugaDevolve>();

    public virtual Pessoa PessoaCpfNavigation { get; set; } = null!;
}
