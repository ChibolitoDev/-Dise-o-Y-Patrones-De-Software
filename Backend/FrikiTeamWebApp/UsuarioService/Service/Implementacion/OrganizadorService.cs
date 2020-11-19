using System.Collections.Generic;
using FrikiTeamWebApp.Models;
using FrikiTeamWebApp.Repositorys;
using FrikiTeamWebApp.UsuarioService.Repository;
using FrikiTeamWebApp.UsuarioService.Repository.Implementacion;

namespace FrikiTeamWebApp.UsuarioService.Service.Implementacion
{
    public class OrganizadorService : IOrganizadorService
    {
        private OrganizadorRepository _organizadorRepository;
        private FrikiTeamBDEntities4 db;


        public OrganizadorService(FrikiTeamBDEntities4 db)
        {
            this.db = db;
            this._organizadorRepository= new OrganizadorRepository(this.db);
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