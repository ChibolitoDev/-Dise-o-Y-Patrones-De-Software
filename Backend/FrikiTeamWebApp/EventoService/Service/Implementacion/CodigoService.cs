using System.Collections.Generic;
using FrikiTeamWebApp.Models;
using FrikiTeamWebApp.EventoService.Repository;
using FrikiTeamWebApp.EventoService.Repository.Implementacion;

namespace FrikiTeamWebApp.EventoService.Service.Implementacion
{
    public class CodigoService : ICodigoService
    {
        private CodigoEventoRepository _codigoEvento;
        private FrikiTeamBDEntities4 db;

        public CodigoService(FrikiTeamBDEntities4 db)
        {
            this.db = db;

            this._codigoEvento=new CodigoEventoRepository(db);
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