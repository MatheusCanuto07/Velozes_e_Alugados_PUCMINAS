using ApiTeste.Domain.DTOs;

namespace ApiTeste.Domain.Models.Funcionario
{
    public interface IFuncionariorepository
    {
        void Add(Funcionario funcionario);

        List<FuncionarioDTO> get(int pageNumber, int pageQuantity);

        Funcionario? Get(int id);
    }
}
