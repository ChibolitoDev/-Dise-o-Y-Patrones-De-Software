using System.Collections.Generic;
using FrikiTeamWebApp.Models;

namespace FrikiTeamWebApp.Repositorys
{
    public interface IEventoRepository : IRepository<Evento>
    {
         List<Evento> FindByName(string Name);
         List<Evento> FindByDireccion(string Direccion);
         List<Evento> FindByDistrito(string Distrito);
    }
}