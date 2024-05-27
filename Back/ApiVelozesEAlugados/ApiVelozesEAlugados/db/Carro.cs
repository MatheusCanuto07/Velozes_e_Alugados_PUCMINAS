using System;
using System.Collections.Generic;

namespace ApiVelozesEAlugados.db;

public partial class Carro
{
    public string Placa { get; set; } = null!;

    public string Modelo { get; set; } = null!;

    public string Marca { get; set; } = null!;

    public string? Cor { get; set; }

    public int? Ano { get; set; }

    public int? Km { get; set; }

    public sbyte? Disponibilidade { get; set; }

    public decimal? PrecoKm { get; set; }

    public decimal? PrecoDiaria { get; set; }

    public string? Observacoes { get; set; }

    public virtual ICollection<Alteracao> Alteracao { get; set; } = new List<Alteracao>();

    public virtual ICollection<AlugaDevolve> AlugaDevolve { get; set; } = new List<AlugaDevolve>();
}
