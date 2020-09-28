using System.Collections.Generic;
using FrikiTeamWebApp.Models;
using FrikiTeamWebApp.Repositorys;

namespace FrikiTeamWebApp.Services.Implementacion
{
    public class EventoService : IEventoService
    {
     
        private IEventoRepository _eventoRepository;

        public EventoService(IEventoRepository eventoRepository)
        {
            this._eventoRepository=eventoRepository;
        }
        
        public bool save(Evento entity)
        {
            return _eventoRepository.save(entity);
        }

        public bool Update(Evento entity)
        {
            return _eventoRepository.Update(entity);
        }

        public bool Delete(int id)
        {
            return _eventoRepository.Delete(id);
        }

        public IEnumerable<Evento> GetAll()
        {
            return _eventoRepository.GetAll();
        }
        public List<Evento> FindByName(string Name)
        {
            return _eventoRepository.FindByName(Name);
        }

        public List<Evento> FindByDireccion(string Direccion)
        {
            return _eventoRepository.FindByDireccion(Direccion);
        }

        public List<Evento> FindByDistrito(string Distrito)
        {
            return _eventoRepository.FindByDistrito(Distrito);
        }
    }
}