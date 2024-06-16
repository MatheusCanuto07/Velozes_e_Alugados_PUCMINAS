using System;
using System.Collections.Generic;
using ApiVelozesEAlugados.Domain.Models.Relacoes;
using CarroName;
using ClienteName;
using FuncionarioNameSpace;
using Microsoft.EntityFrameworkCore;
using PessoaNamespace;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;
using Relacoes;
using Telefone;
using UsuarioName;

namespace ApiVelozesEAlugados.db;

public partial class DbFuriososContext : DbContext
{
    public DbFuriososContext()
    {
    }

    public DbFuriososContext(DbContextOptions<DbFuriososContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Alteracao> Alteracao { get; set; }

    public virtual DbSet<AlugaDevolve> AlugaDevolve { get; set; }

    public virtual DbSet<Carro> Carro { get; set; }

    public virtual DbSet<Cliente> Cliente { get; set; }

    public virtual DbSet<Funcionario> Funcionario { get; set; }

    public virtual DbSet<Pessoa> Pessoa { get; set; }

    public virtual DbSet<Telefones> Telefones { get; set; }

    public virtual DbSet<Usuario> Usuario { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseMySql("server=localhost;port=33066;uid=root;pwd=245199;database=db_furiosos", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.33-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb3_general_ci")
            .HasCharSet("utf8mb3");

        modelBuilder.Entity<Alteracao>(entity =>
        {
            entity.HasKey(e => e.CodAlteracao).HasName("PRIMARY");

            entity.ToTable("alteracao");

            entity.HasIndex(e => e.CodAlteracao, "COD_ALTERACAO_UNIQUE").IsUnique();

            entity.HasIndex(e => e.CarroPlaca, "fk_ALTERACAO_CARRO1_idx");

            entity.HasIndex(e => e.FuncionarioMatricula, "fk_ALTERACAO_FUNCIONARIO1_idx");

            entity.Property(e => e.CodAlteracao)
                .ValueGeneratedNever()
                .HasColumnName("COD_ALTERACAO");
            entity.Property(e => e.CarroPlaca)
                .HasMaxLength(9)
                .HasColumnName("CARRO_PLACA");
            entity.Property(e => e.FuncionarioMatricula).HasColumnName("FUNCIONARIO_MATRICULA");
            entity.Property(e => e.TipoAlteracao)
                .HasMaxLength(45)
                .HasColumnName("TIPO_ALTERACAO");
            entity.Property(e => e.ValorAntigo)
                .HasPrecision(5, 2)
                .HasColumnName("VALOR_ANTIGO");
            entity.Property(e => e.ValorAtual)
                .HasPrecision(5, 2)
                .HasColumnName("VALOR_ATUAL");

            entity.HasOne(d => d.CarroPlacaNavigation).WithMany(p => p.Alteracao)
                .HasForeignKey(d => d.CarroPlaca)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_ALTERACAO_CARRO1");

            entity.HasOne(d => d.FuncionarioMatriculaNavigation).WithMany(p => p.Alteracao)
                .HasForeignKey(d => d.FuncionarioMatricula)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_ALTERACAO_FUNCIONARIO1");
        });

        modelBuilder.Entity<AlugaDevolve>(entity =>
        {
            entity.HasKey(e => e.CodLocacao).HasName("PRIMARY");

            entity.ToTable("aluga_devolve");

            entity.HasIndex(e => e.CarroPlaca, "fk_ALUGA_DEVOLVE_CARRO1_idx");

            entity.HasIndex(e => e.ClientePessoaCpf, "fk_ALUGA_DEVOLVE_CLIENTE1_idx");

            entity.Property(e => e.CodLocacao)
                .ValueGeneratedNever()
                .HasColumnName("COD_LOCACAO");
            entity.Property(e => e.CarroPlaca)
                .HasMaxLength(9)
                .HasColumnName("CARRO_PLACA");
            entity.Property(e => e.ClientePessoaCpf)
                .HasMaxLength(11)
                .IsFixedLength()
                .HasColumnName("CLIENTE_PESSOA_CPF");
            entity.Property(e => e.DataFim).HasColumnName("DATA_FIM");
            entity.Property(e => e.DataInicio).HasColumnName("DATA_INICIO");
            entity.Property(e => e.InfoLocacao)
                .HasMaxLength(200)
                .HasColumnName("INFO_LOCACAO");
            entity.Property(e => e.KmFinal).HasColumnName("KM_FINAL");
            entity.Property(e => e.KmInicial).HasColumnName("KM_INICIAL");
            entity.Property(e => e.ValorTotal)
                .HasPrecision(5, 2)
                .HasColumnName("VALOR_TOTAL");

            entity.HasOne(d => d.CarroPlacaNavigation).WithMany(p => p.AlugaDevolve)
                .HasForeignKey(d => d.CarroPlaca)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_ALUGA_DEVOLVE_CARRO1");

            entity.HasOne(d => d.ClientePessoaCpfNavigation).WithMany(p => p.AlugaDevolve)
                .HasForeignKey(d => d.ClientePessoaCpf)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_ALUGA_DEVOLVE_CLIENTE1");
        });

        modelBuilder.Entity<Carro>(entity =>
        {
            entity.HasKey(e => e.Placa).HasName("PRIMARY");

            entity.ToTable("carro");

            entity.HasIndex(e => e.Placa, "PLACA_UNIQUE").IsUnique();

            entity.Property(e => e.Placa)
                .HasMaxLength(9)
                .HasColumnName("PLACA");
            entity.Property(e => e.Ano).HasColumnName("ANO");
            entity.Property(e => e.Cor)
                .HasMaxLength(45)
                .HasColumnName("COR");
            entity.Property(e => e.Disponibilidade).HasColumnName("DISPONIBILIDADE");
            entity.Property(e => e.Km).HasColumnName("KM");
            entity.Property(e => e.Marca)
                .HasMaxLength(45)
                .HasColumnName("MARCA");
            entity.Property(e => e.Modelo)
                .HasMaxLength(45)
                .HasColumnName("MODELO");
            entity.Property(e => e.Observacoes)
                .HasMaxLength(100)
                .HasColumnName("OBSERVACOES");
            entity.Property(e => e.PrecoDiaria)
                .HasPrecision(5, 2)
                .HasColumnName("PRECO_DIARIA");
            entity.Property(e => e.PrecoKm)
                .HasPrecision(5, 2)
                .HasColumnName("PRECO_KM");
        });

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.PessoaCpf).HasName("PRIMARY");

            entity.ToTable("cliente");

            entity.HasIndex(e => e.PessoaCpf, "fk_CLIENTE_PESSOA1_idx");

            entity.Property(e => e.PessoaCpf)
                .HasMaxLength(11)
                .IsFixedLength()
                .HasColumnName("PESSOA_CPF");
            entity.Property(e => e.CnpjCliente)
                .HasMaxLength(14)
                .IsFixedLength()
                .HasColumnName("CNPJ_CLIENTE");
            entity.Property(e => e.TipoCliente)
                .HasMaxLength(45)
                .HasColumnName("TIPO_CLIENTE");

            entity.HasOne(d => d.PessoaCpfNavigation).WithOne(p => p.Cliente)
                .HasForeignKey<Cliente>(d => d.PessoaCpf)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_CLIENTE_PESSOA1");
        });

        modelBuilder.Entity<Funcionario>(entity =>
        {
            entity.HasKey(e => e.Matricula).HasName("PRIMARY");

            entity.ToTable("funcionario");

            entity.HasIndex(e => e.Matricula, "MATRICULA_UNIQUE").IsUnique();

            entity.HasIndex(e => e.PessoaCpf, "fk_FUNCIONARIO_PESSOA1_idx");

            entity.Property(e => e.Matricula)
                .ValueGeneratedNever()
                .HasColumnName("MATRICULA");
            entity.Property(e => e.Cargo)
                .HasMaxLength(45)
                .HasColumnName("CARGO");
            entity.Property(e => e.PessoaCpf)
                .HasMaxLength(11)
                .IsFixedLength()
                .HasColumnName("PESSOA_CPF");

            entity.HasOne(d => d.PessoaCpfNavigation).WithMany(p => p.Funcionario)
                .HasForeignKey(d => d.PessoaCpf)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_FUNCIONARIO_PESSOA1");
        });

        modelBuilder.Entity<Pessoa>(entity =>
        {
            entity.HasKey(e => e.Cpf).HasName("PRIMARY");

            entity.ToTable("pessoa");

            entity.HasIndex(e => e.Cpf, "CPF_UNIQUE").IsUnique();

            entity.Property(e => e.Cpf)
                .HasMaxLength(11)
                .IsFixedLength()
                .HasColumnName("CPF");
            entity.Property(e => e.Bairro)
                .HasMaxLength(45)
                .HasColumnName("BAIRRO");
            entity.Property(e => e.CepPessoa)
                .HasMaxLength(8)
                .IsFixedLength()
                .HasColumnName("CEP_PESSOA");
            entity.Property(e => e.Cidade)
                .HasMaxLength(45)
                .HasColumnName("CIDADE");
            entity.Property(e => e.CnhPessoa)
                .HasMaxLength(11)
                .IsFixedLength()
                .HasColumnName("CNH_PESSOA");
            entity.Property(e => e.Complemento)
                .HasMaxLength(20)
                .HasColumnName("COMPLEMENTO");
            entity.Property(e => e.DataNascimento).HasColumnName("DATA_NASCIMENTO");
            entity.Property(e => e.Logradouro)
                .HasMaxLength(100)
                .HasColumnName("LOGRADOURO");
            entity.Property(e => e.NomePessoa)
                .HasMaxLength(100)
                .HasColumnName("NOME_PESSOA");
            entity.Property(e => e.Numero)
                .HasMaxLength(15)
                .HasColumnName("NUMERO");
            entity.Property(e => e.Sexo)
                .HasMaxLength(1)
                .IsFixedLength()
                .HasColumnName("SEXO");
            entity.Property(e => e.Uf)
                .HasMaxLength(2)
                .IsFixedLength()
                .HasColumnName("UF");
        });

        modelBuilder.Entity<Telefones>(entity =>
        {
            entity.HasKey(e => new { e.PessoaCpf1, e.NumTelefone })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

            entity.ToTable("telefones");

            entity.HasIndex(e => e.PessoaCpf1, "fk_TELEFONES_PESSOA1_idx");

            entity.Property(e => e.PessoaCpf1)
                .HasMaxLength(11)
                .IsFixedLength()
                .HasColumnName("PESSOA_CPF1");
            entity.Property(e => e.NumTelefone)
                .HasMaxLength(10)
                .HasColumnName("NUM_TELEFONE");

            entity.HasOne(d => d.PessoaCpf1Navigation).WithMany(p => p.Telefones)
                .HasForeignKey(d => d.PessoaCpf1)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_TELEFONES_PESSOA1");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => new { e.Email, e.PessoaCpf })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

            entity.ToTable("usuario");

            entity.HasIndex(e => e.Email, "EMAIL_UNIQUE").IsUnique();

            entity.HasIndex(e => e.PessoaCpf, "fk_USUARIO_PESSOA1_idx");

            entity.Property(e => e.Email)
                .HasMaxLength(20)
                .HasColumnName("EMAIL");
            entity.Property(e => e.PessoaCpf)
                .HasMaxLength(11)
                .IsFixedLength()
                .HasColumnName("PESSOA_CPF");
            entity.Property(e => e.Senha).HasColumnName("SENHA");

            entity.HasOne(d => d.PessoaCpfNavigation).WithMany(p => p.Usuario)
                .HasForeignKey(d => d.PessoaCpf)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_USUARIO_PESSOA1");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}