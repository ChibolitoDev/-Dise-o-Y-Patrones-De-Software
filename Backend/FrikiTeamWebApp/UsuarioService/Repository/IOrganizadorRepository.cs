using FrikiTeamWebApp.Models;
using FrikiTeamWebApp.Repositorys;

namespace FrikiTeamWebApp.UsuarioService.Repository
{
    public interface IOrganizadorRepository : IRepository<Organizador>
    {
         Organizador GetById(int id);
         bool Calificar(int id, int calificacion);
    }
}