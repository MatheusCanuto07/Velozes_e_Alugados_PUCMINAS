using ApiTeste.Domain.DTOs;
using ApiTeste.Domain.Models.Funcionario;
using Microsoft.AspNetCore.Connections;


namespace ApiTeste.Infraestrutura.Repositories
{
    public class FuncionarioRepository : IFuncionariorepository
    {
        private readonly ConnectionContext _context = new ConnectionContext();

        public void Add(Funcionario funcionario)
        {
            _context.funcionario.Add(funcionario);
            _context.SaveChanges();
        }

        public List<FuncionarioDTO> get(int pageNumber, int pageQuantity)
        {
            return _context.funcionario
                .Skip(pageNumber * pageQuantity)
                .Select(f => 
                //Sem auto mapper
                    new FuncionarioDTO()
                    {
                        idfuncionario = f.idfuncionario,
                        nome = f.nome,
                        foto = f.foto,
                    })
                .Take(pageQuantity)
                .ToList();
        }

        public Funcionario? Get(int id)
        {
            //Com automapper
            return _context.funcionario.Find(id);
        }
    }
}
