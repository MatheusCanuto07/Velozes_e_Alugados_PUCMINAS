using ApiTeste.Domain.DTOs;
using ApiTeste.Domain.Models.Funcionario;
using AutoMapper;

namespace ApiTeste.Application.Mapping
{
    public class DomainToDTOMapping : Profile
    {
        public DomainToDTOMapping() 
        { 
            //Como os atributos são iguais só isso basta
            CreateMap<Funcionario, FuncionarioDTO> ();
            //Quando não for utilizar essa função
            //.ForMember()
        }
    }
}
