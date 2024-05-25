using ApiTeste.Domain.Models.Funcionario;
using ApiTeste.Domain.Models.Setor;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Configuration;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace ApiTeste.Infraestrutura.Repositories
{
    public class ConnectionContext : DbContext
    {
        //Faz o mapeamento no banco
        public DbSet<Funcionario> funcionario { get; set; }
        public DbSet<Setor> setor { get; set; }
        //Subescreve um metodo
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseMySQL(
            "Server=localhost;" +
            "Port=5432; Database = db_funcionario;" +
            "User Id = postgres;" +
            "Password = 7198;");
    }
}
