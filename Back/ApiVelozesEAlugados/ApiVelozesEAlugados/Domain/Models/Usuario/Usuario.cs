using System;
using System.Collections.Generic;
using ApiVelozesEAlugados.Application.ViewModel;
using PessoaNamespace;

namespace UsuarioName;

public partial class Usuario
{
    public Usuario(PessoaViewModel p)
    {
        this.Email = p.Email;
        this.Senha = p.Senha;
        this.PessoaCpf = p.CPF;
        this.Tipo = p.TIPO;
    }

    public Usuario() { }

    public string Email { get; set; } = null!;

    public string? Senha { get; set; }

    public string PessoaCpf { get; set; } = null!;

    public string Tipo { get; set; } = null!;

    public virtual Pessoa PessoaCpfNavigation { get; set; } = null!;
}
