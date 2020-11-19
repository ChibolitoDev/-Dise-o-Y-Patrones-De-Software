using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;
using FrikiTeamWebApp.EventoService.Service;
using FrikiTeamWebApp.EventoService.Service.Implementacion;
using FrikiTeamWebApp.Models;

namespace FrikiTeamWebApp.EventoService.Controller
{
    public class CodigoEventoesController : ApiController
    {
        private FrikiTeamBDEntities4 db = new FrikiTeamBDEntities4();
        private readonly CodigoService _codigoService;
        private readonly Service.Implementacion.EventoService _eventoService;
        public CodigoEventoesController()
        {
            this._codigoService = new CodigoService(db);
            this._eventoService = new Service.Implementacion.EventoService(db);
        }

        // GET: api/CodigoEventoes
        public IEnumerable<CodigoEvento> GetCodigoEvento()
        {
            return _codigoService.GetAll();
        }


        // POST: api/CodigoEventoes
        [ResponseType(typeof(CodigoEvento))]
        public IHttpActionResult PostCodigoEvento(CodigoEvento codigoEvento)
        {
            return Ok(_codigoService.save(codigoEvento));
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }



        private bool CodigoEventoExists(int id)
        {
            return db.CodigoEvento.Count(e => e.IDCodigo == id) > 0;
        }
    }
}