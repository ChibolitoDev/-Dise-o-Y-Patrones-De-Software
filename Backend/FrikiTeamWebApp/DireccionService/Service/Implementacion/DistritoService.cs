using System.Collections.Generic;
using FrikiTeamWebApp.DireccionService.Repository;
using FrikiTeamWebApp.Models;
using FrikiTeamWebApp.Repositorys;

namespace FrikiTeamWebApp.DireccionService.Service.Implementacion
{
    public class DistritoService :IDistritoService
    {
        private IDistritoRepository _distritoRepository ;

        public DistritoService(IDistritoRepository distritoRepository)
        {
            this._distritoRepository=distritoRepository;
        }
        
        public bool save(Distrito entity)
        {
            return _distritoRepository.save(entity);
        }

        public bool Update(Distrito entity)
        {
            return _distritoRepository.Update(entity);
        }

        public bool Delete(int id)
        {
            return _distritoRepository.Delete(id);
        }

        public IEnumerable<Distrito> GetAll()
        {
            return _distritoRepository.GetAll();
        }
    }
}