using System;
using System.Collections.Generic;
using ApiVelozesEAlugados.Domain.Models.Relacoes;
using Microsoft.EntityFrameworkCore;
using Relacoes;
using ApiVelozesEAlugados.ViewModel;
using ApiVelozesEAlugados.Application.ViewModel;

namespace CarroName;

public partial class Carro
{
    public Carro() 
    { 

    }

    public Carro(CarroViewModel cmv)
    {
        this.Placa = cmv.Placa;
        this.Modelo = cmv.Modelo;
        this.Marca = cmv.Marca;
        this.Cor = cmv.Cor;
        this.Ano = cmv.Ano;
        this.Km = cmv.Km;
        this.Disponibilidade = cmv.Disponibilidade;
        this.PrecoKm = cmv.PrecoKm;
        this.PrecoDiaria = cmv.PrecoDiaria;
        this.Observacoes = cmv.Observacoes;
        this.Endereco_imagem = cmv.Endereco_imagem;
        
    }
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
    public string? Endereco_imagem { get; set; }

    public virtual ICollection<Alteracao> Alteracao { get; set; } = new List<Alteracao>();

    public virtual ICollection<AlugaDevolve> AlugaDevolve { get; set; } = new List<AlugaDevolve>();
}
