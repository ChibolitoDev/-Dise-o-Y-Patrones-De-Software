using System.Collections.Generic;
using FrikiTeamWebApp.Models;
using FrikiTeamWebApp.Services;

namespace FrikiTeamWebApp.EventoService.Service
{
    public interface IEventoService : IService<Evento>
    {
         List<Evento> FindByName(string Name);
         List<Evento> FindByDireccion(string Direccion);
         List<Evento> FindByDistrito(string Distrito);
    }
}