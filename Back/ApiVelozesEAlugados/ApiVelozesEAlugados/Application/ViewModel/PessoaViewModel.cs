using Microsoft.VisualBasic;

namespace ApiVelozesEAlugados.Application.ViewModel
{
    public class PessoaViewModel
    {
        public string CPF { get; set; }
        public string? NOME_PESSOA { get; set; }
        public DateTime? DATA_NASCIMENTO { get; set; }
        public string? CNH_PESSOA { get; set; }
        public string? CEP_PESSOA { get; set; }
        public string? LOGRADOURO { get; set; }
        public string? NUMERO { get; set; }
        public string? COMPLEMENTO { get; set; }
        public string? BAIRRO { get; set; }
        public string? CIDADE { get; set; }
        public string? UF { get; set; }
        public string? SEXO { get; set; }
    }
}
