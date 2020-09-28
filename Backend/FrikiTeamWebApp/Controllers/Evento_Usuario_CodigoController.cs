using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Web.Http;
using System.Web.Http.Description;
using FrikiTeamWebApp.Models;
using FrikiTeamWebApp.Services;
using FrikiTeamWebApp.Services.Implementacion;

namespace FrikiTeamWebApp.Controllers
{
    public class Evento_Usuario_CodigoController : ApiController
    {
        private FrikiTeamBDEntities4 db = new FrikiTeamBDEntities4();
        private readonly IEventoUsuarioCodigoService _eventoUsuarioCodigoService;
        private readonly ICodigoService _codigoService;
        private readonly IEventoService _eventoService;

        public Evento_Usuario_CodigoController(CodigoService codigoService, EventoUsuarioCodigoService eventoUsuarioCodigoService, EventoService eventoService)
        {
            this._eventoUsuarioCodigoService = eventoUsuarioCodigoService;
            this._codigoService = codigoService;
            this._eventoService = eventoService;
        }


        // GET: api/Evento_Usuario_Codigo
        public IEnumerable<Evento_Usuario_Codigo> GetEvento_Usuario_Codigo()
        {
            return _eventoUsuarioCodigoService.GetAll();
        }

        // POST: api/Evento_Usuario_Codigo
        [ResponseType(typeof(Evento_Usuario_Codigo))]
        public IHttpActionResult PostEvento_Usuario_Codigo(Evento_Usuario_Codigo evento_Usuario_Codigo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            try
            {
                _eventoUsuarioCodigoService.save(evento_Usuario_Codigo);
            }
            catch (DbUpdateException)
            {
                if (Evento_Usuario_CodigoExists(evento_Usuario_Codigo.IEUC))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = evento_Usuario_Codigo.IEUC }, evento_Usuario_Codigo);
        }

        // DELETE: api/Evento_Usuario_Codigo/5
        [ResponseType(typeof(Evento_Usuario_Codigo))]
        public IHttpActionResult DeleteEvento_Usuario_Codigo(int id)
        {
            Evento_Usuario_Codigo evento_Usuario_Codigo = db.Evento_Usuario_Codigo.Find(id);

            Evento_Usuario evento_Usuario = evento_Usuario_Codigo.Evento_Usuario;
            Evento evento = evento_Usuario_Codigo.Evento_Usuario.Evento;
            CodigoEvento codigoEvento = evento_Usuario_Codigo.CodigoEvento;


            if (evento_Usuario_Codigo == null)
            {
                return NotFound();
            }
            evento.NCupos += 1;
            _eventoService.Update(evento);
            _eventoUsuarioCodigoService.Delete(evento_Usuario_Codigo.IEUC);
            _codigoService.Delete(codigoEvento.IDCodigo);
            db.SaveChanges();

            return Ok(evento_Usuario_Codigo);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Evento_Usuario_CodigoExists(int id)
        {
            return db.Evento_Usuario_Codigo.Count(e => e.IEUC == id) > 0;
        }
    }
}