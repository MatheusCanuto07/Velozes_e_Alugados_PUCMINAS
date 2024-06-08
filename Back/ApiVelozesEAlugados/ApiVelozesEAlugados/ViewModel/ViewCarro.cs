namespace ApiVelozesEAlugados.ViewModel
{
    public class ViewCarro
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
    }
}
