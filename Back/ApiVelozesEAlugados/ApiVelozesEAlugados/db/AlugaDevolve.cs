﻿using System;
using System.Collections.Generic;

namespace ApiVelozesEAlugados.db;

public partial class AlugaDevolve
{
    public int CodLocacao { get; set; }

    public string ClientePessoaCpf { get; set; } = null!;

    public string CarroPlaca { get; set; } = null!;

    public DateOnly? DataInicio { get; set; }

    public DateOnly? DataFim { get; set; }

    public decimal? ValorTotal { get; set; }

    public int? KmInicial { get; set; }

    public int? KmFinal { get; set; }

    public string? InfoLocacao { get; set; }

    public virtual Carro CarroPlacaNavigation { get; set; } = null!;

    public virtual Cliente ClientePessoaCpfNavigation { get; set; } = null!;
}
