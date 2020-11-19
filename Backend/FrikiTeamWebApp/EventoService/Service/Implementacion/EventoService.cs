using System;
using System.Collections.Generic;
using FrikiTeamWebApp.EventoService.Repository;
using FrikiTeamWebApp.EventoService.Repository.Implementacion;
using FrikiTeamWebApp.Models;
using FrikiTeamWebApp.Repositorys;

namespace FrikiTeamWebApp.EventoService.Service.Implementacion
{
    public class EventoService : IEventoService
    {
     
        private EventoRepository _eventoRepository;
        private FrikiTeamBDEntities4 db;

        public EventoService(FrikiTeamBDEntities4 db)
        {
            this.db = db;
            this._eventoRepository=new EventoRepository(db);
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
        public IEnumerable<Evento> FindByName(string Name)
        {
            return _eventoRepository.FindByName(Name);
        }


        public IEnumerable<Evento> FindByDireccion(string Direccion)
        {
            return _eventoRepository.FindByDireccion(Direccion);
        }

        public IEnumerable<Evento> FindByDistrito(string Distrito)
        {
            return _eventoRepository.FindByDistrito(Distrito);
        }
    }
}