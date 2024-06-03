using System;
using System.Collections.Generic;
using CarroName;
using FuncionarioNameSpace;

namespace Relacoes;

public partial class Alteracao
{
    public int CodAlteracao { get; set; }

    public int FuncionarioMatricula { get; set; }

    public string CarroPlaca { get; set; } = null!;

    public string? TipoAlteracao { get; set; }

    public decimal? ValorAntigo { get; set; }

    public decimal? ValorAtual { get; set; }

    public virtual Carro CarroPlacaNavigation { get; set; } = null!;

    public virtual Funcionario FuncionarioMatriculaNavigation { get; set; } = null!;
}
