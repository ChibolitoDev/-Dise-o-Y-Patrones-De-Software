using System.Collections.Generic;
using FrikiTeamWebApp.Repositorys;
using FrikiTeamWebApp.Models;
using FrikiTeamWebApp.Repositorys.Implementacion;
using FrikiTeamWebApp.EventoService.Service;
using FrikiTeamWebApp.EventoService.Repository;

namespace FrikiTeamWebApp.EventoService.Service.Implementacion
{
    public class CodigoService : ICodigoService
    {
        private ICodigoEvento _codigoEvento;

        public CodigoService(ICodigoEvento codigoEvento)
        {
            this._codigoEvento=codigoEvento;
        }
        
        public bool save(CodigoEvento entity)
        {
            return _codigoEvento.save(entity);
        }

        public bool Update(CodigoEvento entity)
        {
            return _codigoEvento.Update(entity);
        }

        public bool Delete(int id)
        {
            return _codigoEvento.Delete(id);
        }

        public IEnumerable<CodigoEvento> GetAll()
        {
            return _codigoEvento.GetAll();
        }
    }
}