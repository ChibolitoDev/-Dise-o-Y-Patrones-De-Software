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
    public class Evento_UsuarioController : ApiController
    {
        private FrikiTeamBDEntities4 db = new FrikiTeamBDEntities4();
        private readonly EventoUsuarioService _eventoUsuarioService;
        private readonly Service.Implementacion.EventoService _eventoService;

        public Evento_UsuarioController()
        {
            this._eventoUsuarioService = new EventoUsuarioService(db);
            this._eventoService = new Service.Implementacion.EventoService(db); 
        }

        // GET: api/Evento_Usuario
        public IEnumerable<Evento_Usuario> GetEvento_Usuario()
        {
            return _eventoUsuarioService.GetAll();
        }



        // POST: api/Evento_Usuario
        [ResponseType(typeof(Evento_Usuario))]
        public IHttpActionResult PostEvento_Usuario(Evento_Usuario evento_Usuario)
        {
            return Ok(_eventoUsuarioService.save(evento_Usuario));
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