using System.Collections.Generic;
using FrikiTeamWebApp.Models;

namespace FrikiTeamWebApp.Services
{
    public interface IEventoService : IService<Evento>
    {
         List<Evento> FindByName(string Name);
         List<Evento> FindByDireccion(string Direccion);
         List<Evento> FindByDistrito(string Distrito);
    }
}