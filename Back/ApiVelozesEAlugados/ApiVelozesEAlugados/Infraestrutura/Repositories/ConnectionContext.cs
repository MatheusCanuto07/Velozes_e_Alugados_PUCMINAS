using ApiTeste.Domain.Models.Funcionario;
using ApiTeste.Domain.Models.Setor;
using ApiVelozesEAlugados.db;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Configuration;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace ApiTeste.Infraestrutura.Repositories
{
    public class ConnectionContext : DbFuriososContext 

    {
    
        //Faz o mapeamento no banco
        public DbSet<Pessoa> pessoa { get; set; }
        public DbSet<Setor> setor { get; set; }
        //Subescreve um metodo
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseMySql("server=localhost;port=3306;uid=root;pwd=245199;database=db_furiosos", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.33-mysql"));

    }
}
