﻿namespace ApiVelozesEAlugados.Application.ViewModel
{
    public class AlugaDevolveViewModel
    {
        private int codLocacao;
        private DateTime? dataInicio1;
        private DateTime? dataFim1;
        private decimal? valorTotal;
        private int? kmInicial;
        private int? kmFinal;
        private string? infoLocacao;

        public AlugaDevolveViewModel(string cliente_pessoa_cpf, string carro_placa, DateTime? data_inicio, DateTime? data_fim, decimal? valor_total, int? km_inicial, int? km_final, string? info_locacao)
        {
            Cliente_pessoa_cpf = cliente_pessoa_cpf;
            Carro_placa = carro_placa;
            this.dataInicio = data_inicio;
            this.dataFim = data_fim;
            this.ValorTotal = valor_total;
            this.KmInicial = km_inicial;
            this.KmFinal = km_final;
            this.InfoLocacao = info_locacao;
        }
        public AlugaDevolveViewModel()
        {

        }

        public int CodLocacao { get => codLocacao; set => codLocacao = value; }
        public string Cliente_pessoa_cpf { get; set; } = null!;
        public string Carro_placa { get; set; } = null!;
        public DateTime? dataInicio { get => dataInicio1; set => dataInicio1 = value; }
        public DateTime? dataFim { get => dataFim1; set => dataFim1 = value; }
        public decimal? ValorTotal { get => valorTotal; set => valorTotal = value; }
        public int? KmInicial { get => kmInicial; set => kmInicial = value; }
        public int? KmFinal { get => kmFinal; set => kmFinal = value; }
        public string? InfoLocacao { get => infoLocacao; set => infoLocacao = value; }

    }
}
