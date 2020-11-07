using System.Collections.Generic;
using FrikiTeamWebApp.DireccionService.Repository;
using FrikiTeamWebApp.Models;

namespace FrikiTeamWebApp.DireccionService.Service.Implementacion
{
    public class CalleService : ICalleService
    {
        private ICalleRepository _calleRepository;

        public CalleService(ICalleRepository calleRepository)
        {
            this._calleRepository=calleRepository;
        }
        
        public bool save(Calle entity)
        {
            return _calleRepository.save(entity);
        }

        public bool Update(Calle entity)
        {
            return _calleRepository.Update(entity);
        }

        public bool Delete(int id)
        {
            return _calleRepository.Delete(id);
        }

        public IEnumerable<Calle> GetAll()
        {
            return _calleRepository.GetAll();
        }
    }
}