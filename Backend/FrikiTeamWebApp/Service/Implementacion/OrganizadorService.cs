using System.Collections.Generic;
using FrikiTeamWebApp.Models;
using FrikiTeamWebApp.Repositorys;

namespace FrikiTeamWebApp.Services.Implementacion
{
    public class OrganizadorService : IOrganizadorService
    {
        private IOrganizadorRepository _organizadorRepository;

        public OrganizadorService(IOrganizadorRepository organizadorRepository)
        {
            this._organizadorRepository=organizadorRepository;
        }
        public bool save(Organizador entity)
        {
            return _organizadorRepository.save(entity);
        }

        public bool Update(Organizador entity)
        {
            return _organizadorRepository.save(entity);
        }

        public bool Delete(int id)
        {
            return _organizadorRepository.Delete(id);
        }

        public IEnumerable<Organizador> GetAll()
        {
            return _organizadorRepository.GetAll();
        }

        public Organizador GetById(int id)
        {
            return _organizadorRepository.GetById(id);
        }

        public bool Calificar(int id, int calificacion)
        {
            return _organizadorRepository.Calificar(id,calificacion);
        }
    }
}