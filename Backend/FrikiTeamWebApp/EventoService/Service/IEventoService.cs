using System.Collections.Generic;
using FrikiTeamWebApp.Models;
using FrikiTeamWebApp.Services;

namespace FrikiTeamWebApp.EventoService.Service
{
    public interface IEventoService : IService<Evento>
    {
        IEnumerable<Evento> FindByName(string Name);
        IEnumerable<Evento> FindByDireccion(string Direccion);
        IEnumerable<Evento> FindByDistrito(string Distrito);
    }
}