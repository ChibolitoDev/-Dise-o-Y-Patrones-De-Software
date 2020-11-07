using FrikiTeamWebApp.Models;
using FrikiTeamWebApp.Services;

namespace FrikiTeamWebApp.UsuarioService.Service
{
    public interface IClienteService : IService<Cliente>
    {
         Cliente GetById(int id);

    }
}