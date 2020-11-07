using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;
using FrikiTeamWebApp.EventoService.Service;
using FrikiTeamWebApp.EventoService.Service.Implementacion;
using FrikiTeamWebApp.Models;

namespace FrikiTeamWebApp.EventoService.Controller
{
    public class Evento_UsuarioController : ApiController
    {
        private FrikiTeamBDEntities4 db = new FrikiTeamBDEntities4();
        private readonly IEventoUsuarioService _eventoUsuarioService;
        private readonly IEventoService _eventoService;

        public Evento_UsuarioController(EventoUsuarioService eventoUsuarioService, IEventoService eventoService)
        {
            this._eventoUsuarioService = eventoUsuarioService;
            this._eventoService = eventoService;
        }

        // GET: api/Evento_Usuario
        public IQueryable<Evento_Usuario> GetEvento_Usuario()
        {
            return db.Evento_Usuario;
        }

        // GET: api/Evento_Usuario/5
        [ResponseType(typeof(Evento_Usuario))]
        public IHttpActionResult GetEvento_Usuario(int id)
        {
            Evento_Usuario evento_Usuario = db.Evento_Usuario.Find(id);
            if (evento_Usuario == null)
            {
                return NotFound();
            }

            return Ok(evento_Usuario);
        }

        // PUT: api/Evento_Usuario/5
        [ResponseType(typeof(void))]


        // POST: api/Evento_Usuario
        [ResponseType(typeof(Evento_Usuario))]
        public IHttpActionResult PostEvento_Usuario(Evento_Usuario evento_Usuario)
        {
            Evento evento = db.Evento.Find(evento_Usuario.Evento.IDEvento);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if(evento_Usuario.Evento.NCupos != 0)
            {
                evento.NCupos =- 1;
                _eventoService.Update(evento);
                db.Evento_Usuario.Add(evento_Usuario);
            }


            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (Evento_UsuarioExists(evento_Usuario.IDEvento_Usuario))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = evento_Usuario.IDEvento_Usuario }, evento_Usuario);
        }

        // DELETE: api/Evento_Usuario/5
        [ResponseType(typeof(Evento_Usuario))]
        public IHttpActionResult DeleteEvento_Usuario(int id)
        {
            Evento_Usuario evento_Usuario = db.Evento_Usuario.Find(id);
            if (evento_Usuario == null)
            {
                return NotFound();
            }

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

        private bool Evento_UsuarioExists(int id)
        {
            return db.Evento_Usuario.Count(e => e.IDEvento_Usuario == id) > 0;
        }
    }
}