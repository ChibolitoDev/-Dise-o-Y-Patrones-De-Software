using FrikiTeamWebApp.EventoService.Repository;
using FrikiTeamWebApp.EventoService.Repository.Implementacion;
using FrikiTeamWebApp.Models;
using System.Collections.Generic;

namespace FrikiTeamWebApp.EventoService.Service.Implementacion
{
    public class EventoUsuarioService : IEventoUsuarioService
    {
        private EventoUsuarioRepository repository;
        private FrikiTeamBDEntities4 db;

        public EventoUsuarioService(FrikiTeamBDEntities4 db)
        {
            this.db = db;
            this.repository = new EventoUsuarioRepository(db);
        }
        public bool Delete(int id)
        {
            return repository.Delete(id);
        }

        public IEnumerable<Evento_Usuario> GetAll()
        {
            return repository.GetAll();
        }

        public bool save(Evento_Usuario entity)
        {
            return repository.save(entity);
        }

        public bool Update(Evento_Usuario entity)
        {
            return repository.Update(entity);
        }
    }
}