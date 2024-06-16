using System;
using System.Collections.Generic;
using ApiVelozesEAlugados.Application.ViewModel;
using CarroName;
using ClienteName;
using Microsoft.EntityFrameworkCore;


namespace AlugaDevolveNameSpace;

[Keyless]
public partial class AlugaDevolve
{
    public AlugaDevolve() { 
        
    }

    public AlugaDevolve(AlugaDevolveViewModel AViewModel)
    {
        CodLocacao = AViewModel.CodLocacao;
        ClientePessoaCpf = AViewModel.Cliente_pessoa_cpf;
        CarroPlaca = AViewModel.Carro_placa;
        DataInicio = AViewModel.dataInicio;
        DataFim = AViewModel.dataFim;
        ValorTotal = AViewModel.ValorTotal;
        KmInicial = AViewModel.KmInicial;
        KmFinal = AViewModel.KmFinal;
        InfoLocacao = AViewModel.InfoLocacao;
    }

    public int CodLocacao { get; set; }

    public string ClientePessoaCpf { get; set; } = null!;

    public string CarroPlaca { get; set; } = null!;

    public DateTime? DataInicio { get; set; }

    public DateTime? DataFim { get; set; }

    public decimal? ValorTotal { get; set; }

    public int? KmInicial { get; set; }

    public int? KmFinal { get; set; }

    public string? InfoLocacao { get; set; }

    public virtual Carro CarroPlacaNavigation { get; set; } = null!;

    public virtual Cliente ClientePessoaCpfNavigation { get; set; } = null!;
}
