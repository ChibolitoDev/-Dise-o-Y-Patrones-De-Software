using FrikiTeamWebApp.Models;
using FrikiTeamWebApp.Services;

namespace FrikiTeamWebApp.UsuarioService.Service
{
    public interface IOrganizadorService : IService<Organizador>
    {
         Organizador GetById(int id);
         bool Calificar(int id, int calificacion);
    }
}