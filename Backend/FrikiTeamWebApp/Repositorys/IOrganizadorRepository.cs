using FrikiTeamWebApp.Models;

namespace FrikiTeamWebApp.Repositorys
{
    public interface IOrganizadorRepository : IRepository<Organizador>
    {
         Organizador GetById(int id);
         bool Calificar(int id, int calificacion);
         
    }
}