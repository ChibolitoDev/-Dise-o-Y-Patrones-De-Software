using System.Collections.Generic;
using FrikiTeamWebApp.Models;
using FrikiTeamWebApp.Repositorys;

namespace FrikiTeamWebApp.EventoService.Repository
{
    public interface IEventoRepository : IRepository<Evento>
    {
        
        IEnumerable<Evento> FindByName(string Name);
        IEnumerable<Evento> FindByDireccion(string Direccion);
        IEnumerable<Evento> FindByDistrito(string Distrito);
    }
}