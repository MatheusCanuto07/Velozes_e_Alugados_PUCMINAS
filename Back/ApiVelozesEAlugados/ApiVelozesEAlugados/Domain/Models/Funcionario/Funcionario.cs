using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiTeste.Domain.Models.Funcionario
{
    [Table("funcionario")]
    public class Funcionario
    {
        [Key]
        public int? idfuncionario { get; private set; }
        public string? nome { get; private set; }
        public string? funcao { get; private set; }
        public string? idade { get; private set; }
        public string? foto { get; private set; }

        public Funcionario(string nome, string idade, string foto)
        {
            this.nome = nome ?? throw new ArgumentNullException(nameof(nome));
            this.idade = idade;
            this.foto = foto;
        }
        public Funcionario() { }
    }
}
