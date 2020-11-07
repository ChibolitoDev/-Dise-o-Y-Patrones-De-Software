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
        private readonly ICodigoService _codigoService;
        private readonly IEventoService _eventoService;
        public CodigoEventoesController(CodigoService codigoService, IEventoService eventoService)
        {
            this._codigoService = codigoService;
            this._eventoService = eventoService;
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
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                _codigoService.save(codigoEvento);
            }
            catch (DbUpdateException)
            {
                if (CodigoEventoExists(codigoEvento.IDCodigo))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = codigoEvento.IDCodigo }, codigoEvento);
        }

        // DELETE: api/Evento_Usuario/5
        [ResponseType(typeof(Evento_Usuario))]
        public IHttpActionResult DeleteEvento_Codigo(int id)
        {
            Evento_Usuario evento_Usuario = db.Evento_Usuario.Find(id);
            Evento evento = db.Evento.Find(evento_Usuario.Evento.IDEvento);
            if (evento_Usuario == null)
            {
                return NotFound();
            }
            evento.NCupos += 1;
            _eventoService.Update(evento);
            db.Evento_Usuario.Remove(evento_Usuario);
            db.SaveChanges();

            return Ok(evento_Usuario);
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