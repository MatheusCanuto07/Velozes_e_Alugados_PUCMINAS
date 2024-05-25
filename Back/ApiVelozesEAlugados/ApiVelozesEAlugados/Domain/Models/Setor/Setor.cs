using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiTeste.Domain.Models.Setor
{
    [Table("setor")]
    public class Setor
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
    }
}