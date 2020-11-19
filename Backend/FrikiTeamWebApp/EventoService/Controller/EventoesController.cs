using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using FrikiTeamWebApp.DireccionService.Service;
using FrikiTeamWebApp.DireccionService.Service.Implementacion;
using FrikiTeamWebApp.EventoService.Service;
using FrikiTeamWebApp.Models;
using FrikiTeamWebApp.UsuarioService.Service;
using FrikiTeamWebApp.UsuarioService.Service.Implementacion;

namespace FrikiTeamWebApp.EventoService.Controller
{
    public class EventoesController : ApiController
    {
        private FrikiTeamBDEntities4 db = new FrikiTeamBDEntities4();
        private Service.Implementacion.EventoService _eventoService;
        private OrganizadorService _organizadorService;

        public EventoesController()
        {
            this._organizadorService = new OrganizadorService(db);
            this._eventoService = new Service.Implementacion.EventoService(db);
        }


        [ResponseType(typeof(Evento))]
        public IHttpActionResult AgregarEventoes(Evento Evento)
        {
            return Ok(_eventoService.save(Evento));
        }

        // GET: api/Eventoes
        public IEnumerable<Evento> GetEventos()
        {
            return _eventoService.GetAll();
        }

        // GET: api/Eventoes/5
        [Route("api/Eventoes/SearchByName/{name}")]
        [ResponseType(typeof(List<Evento>))]
        public IHttpActionResult SearchByName(string name)
        {
            return Ok(_eventoService.FindByName(name));
        }

        // GET: api/Eventoes/4
        [Route("api/Eventoes/SearchByDistrito/{name}")]
        [ResponseType(typeof(List<Evento>))]
        public IHttpActionResult SearchByDistrito(string name)
        {
            return Ok(_eventoService.FindByDistrito(name));
        }

        // GET: api/Eventoes/3
        [Route("api/Eventoes/SearchByCalle/{name}")]
        [ResponseType(typeof(List<Evento>))]
        public IHttpActionResult SearchByCalle(string name)
        {
            return Ok(_eventoService.FindByDireccion(name));
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