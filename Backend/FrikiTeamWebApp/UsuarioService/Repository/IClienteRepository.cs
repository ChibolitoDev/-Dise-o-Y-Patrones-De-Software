using FrikiTeamWebApp.Models;
using FrikiTeamWebApp.Repositorys;

namespace FrikiTeamWebApp.UsuarioService.Repository
{
    public interface IClienteRepository : IRepository<Cliente>
    {
        Cliente GetById(int id);

    }
}