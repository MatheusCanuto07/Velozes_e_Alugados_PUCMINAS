﻿using ApiVelozesEAlugados.Application.ViewModel;
using IPessoaRepositoryNameSpace;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using Org.BouncyCastle.Cms;
using PessoaNamespace;
using UsuarioName;

namespace ApiVelozesEAlugados.Infraestrutura.Repositories
{

    public class PessoaRepository : IPessoaRepository
    {
        private readonly ConnectionContext _Contexto = new ConnectionContext();

        public List<Pessoa> Get()
        {
            return _Contexto.Pessoa.ToList();
        }

        public Pessoa GetID(string email, string senha)
        {
            throw new NotImplementedException();
        }

        public PessoaViewModel GetByCpfUsuario(string cpf)
        {
            Pessoa p = _Contexto.Pessoa.FirstOrDefault(p => p.Cpf == cpf);
            Usuario u = _Contexto.Usuario.FirstOrDefault(u => u.PessoaCpf == cpf);

            if (p == null)
            {
                throw new KeyNotFoundException("Pessoa not found.");
            }

            if (u == null)
            {
                throw new KeyNotFoundException("Usuario not found.");
            }

            PessoaViewModel pessoaView = new PessoaViewModel(u, p);

            return pessoaView;
        }

        public void add(PessoaViewModel pessoa)
        {
            Pessoa p = new Pessoa(pessoa);
            Usuario u = new Usuario(pessoa);

            _Contexto.Pessoa.Add(p);
            _Contexto.Usuario.Add(u);
            
            _Contexto.SaveChanges();
        }

        public void Update(string cpf, PessoaViewModel pessoaViewModel)
        {
            var existingPessoa = _Contexto.Pessoa.FirstOrDefault(p => p.Cpf == cpf);

            if (existingPessoa == null)
            {
                throw new Exception("Pessoa not found.");
            }

            existingPessoa.NomePessoa = pessoaViewModel.NOME_PESSOA;
            existingPessoa.DataNascimento = pessoaViewModel.DATA_NASCIMENTO;
            existingPessoa.CnhPessoa = pessoaViewModel.CNH_PESSOA;
            existingPessoa.CepPessoa = pessoaViewModel.CEP_PESSOA;
            existingPessoa.Logradouro = pessoaViewModel.LOGRADOURO;
            existingPessoa.Numero = pessoaViewModel.NUMERO;
            existingPessoa.Complemento = pessoaViewModel.COMPLEMENTO;
            existingPessoa.Bairro = pessoaViewModel.BAIRRO;
            existingPessoa.Cidade = pessoaViewModel.CIDADE;
            existingPessoa.Uf = pessoaViewModel.UF;
            existingPessoa.Sexo = pessoaViewModel.SEXO;

            _Contexto.Pessoa.Update(existingPessoa);
            _Contexto.SaveChanges();
        }

        public PessoaViewModel GetByCpf(string cpf)
        {
            Pessoa p = _Contexto.Pessoa.FirstOrDefault(p => p.Cpf == cpf);
            Usuario u = _Contexto.Usuario.FirstOrDefault(u => u.PessoaCpf == cpf);

            if (p == null)
            {
                throw new KeyNotFoundException("Pessoa not found.");
            }

            if (u == null)
            {
                throw new KeyNotFoundException("Usuario not found.");
            }

            PessoaViewModel pessoaView = new PessoaViewModel(u, p);

            return pessoaView;

        }

    }
}
