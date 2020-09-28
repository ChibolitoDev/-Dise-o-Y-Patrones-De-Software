using FrikiTeamWebApp.Models;
using FrikiTeamWebApp.Repositorys;
using FrikiTeamWebApp.Repositorys.Implementacion;
using FrikiTeamWebApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FrikiTeamWebApp.Service.Implementacion
{
    public class EventoUsuarioService : IEventoUsuarioService
    {
        private IEventoUsuarioRepository repository;

        public EventoUsuarioService(EventoUsuarioRepository repo)
        {
            this.repository = repo;
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