using FrikiTeamWebApp.Models;

namespace FrikiTeamWebApp.Services
{
    public interface IOrganizadorService : IService<Organizador>
    {
         Organizador GetById(int id);
         bool Calificar(int id, int calificacion);
    }
}