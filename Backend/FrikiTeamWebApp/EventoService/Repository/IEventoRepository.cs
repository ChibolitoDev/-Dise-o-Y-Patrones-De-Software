using System.Collections.Generic;
using FrikiTeamWebApp.Models;
using FrikiTeamWebApp.Repositorys;

namespace FrikiTeamWebApp.EventoService.Repository
{
    public interface IEventoRepository : IRepository<Evento>
    {
         List<Evento> FindByName(string Name);
         List<Evento> FindByDireccion(string Direccion);
         List<Evento> FindByDistrito(string Distrito);
    }
}