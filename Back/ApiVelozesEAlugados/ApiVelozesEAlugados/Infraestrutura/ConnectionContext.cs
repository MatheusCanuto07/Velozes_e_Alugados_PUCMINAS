using PessoaNamespace;

using Microsoft.EntityFrameworkCore;
using ApiVelozesEAlugados.db;

namespace ApiVelozesEAlugados.Infraestrutura
{
    public class ConnectionContext : DbFuriososContext
    {
        //Faz o mapeamento no banco
        public DbSet<Pessoa> pessoa { get; set; }
        //Subescreve um metodo
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseMySql("server=localhost;port=3307;uid=root;pwd=Canuto7198;database=db_furiosos", ServerVersion.Parse("8.0.33-mysql"));

    }
}
