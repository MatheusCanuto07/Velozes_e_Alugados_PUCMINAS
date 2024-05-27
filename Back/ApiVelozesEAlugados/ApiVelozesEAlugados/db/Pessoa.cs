using System;
using System.Collections.Generic;

namespace ApiVelozesEAlugados.db;

public partial class Pessoa
{
    public string Cpf { get; set; } = null!;

    public string? NomePessoa { get; set; }

    public DateOnly? DataNascimento { get; set; }

    public string? CnhPessoa { get; set; }

    public string? CepPessoa { get; set; }

    public string? Logradouro { get; set; }

    public string? Numero { get; set; }

    public string? Complemento { get; set; }

    public string? Bairro { get; set; }

    public string? Cidade { get; set; }

    public string? Uf { get; set; }

    public string? Sexo { get; set; }

    public virtual Cliente? Cliente { get; set; }

    public virtual ICollection<Funcionario> Funcionario { get; set; } = new List<Funcionario>();

    public virtual ICollection<Telefones> Telefones { get; set; } = new List<Telefones>();

    public virtual ICollection<Usuario> Usuario { get; set; } = new List<Usuario>();
}
