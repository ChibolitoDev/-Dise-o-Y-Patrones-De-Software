using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.UI.WebControls;
using FrikiTeamWebApp.EventoService.Service;
using FrikiTeamWebApp.Models;
using FrikiTeamWebApp.Services;
using FrikiTeamWebApp.Services.Implementacion;
using FrikiTeamWebApp.UsuarioService.Service;
using FrikiTeamWebApp.UsuarioService.Service.Implementacion;

namespace FrikiTeamWebApp.Controllers
{
    public class EventoesController : ApiController
    {
        private FrikiTeamBDEntities4 db = new FrikiTeamBDEntities4();
        private IEventoService _eventoService;
        private IOrganizadorService _organizadorService;
        private IDistritoService _distritoService;

        public EventoesController(DistritoService distritoService, OrganizadorService organizadorService, IEventoService eventoService)
        {
            this._organizadorService = organizadorService;
            this._distritoService = distritoService;
            this._eventoService = eventoService;
        }

        // GET: api/Eventoes
        public IEnumerable<Evento> ListEventos()
        {
            return _eventoService.GetAll();
        }

        public IEnumerable<Evento> SearchByName(string name)
        {
            return _eventoService.FindByName(name);
        }

        public IEnumerable<Evento> SearchByDistrito(string name)
        {
            return _eventoService.FindByDistrito(name);
        }

        public IEnumerable<Evento> SearchByCalle(string name)
        {
            return _eventoService.FindByDireccion(name);
        }


        // PUT: api/Eventoes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEvento(int id, Evento evento)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != evento.IDEvento)
            {
                return BadRequest();
            }

            db.Entry(evento).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EventoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Eventoes
        [ResponseType(typeof(Evento))]
        public IHttpActionResult PostEvento(Evento evento)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _eventoService.save(evento);
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (EventoExists(evento.IDEvento))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = evento.IDEvento }, evento);
        }

        // DELETE: api/Eventoes/5
        [ResponseType(typeof(Evento))]
        public IHttpActionResult DeleteEvento(int id)
        {
            Evento evento = db.Evento.Find(id);
            if (evento == null)
            {
                return NotFound();
            }

            _eventoService.Delete(id);
            db.SaveChanges();

            return Ok(evento);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EventoExists(int id)
        {
            return db.Evento.Count(e => e.IDEvento == id) > 0;
        }
    }
}