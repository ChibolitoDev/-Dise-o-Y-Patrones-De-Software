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
using FrikiTeamWebApp.Models;

namespace FrikiTeamWebApp.Controllers
{
    public class Evento_Usuario_CodigoController : ApiController
    {
        private FrikiTeamBDEntities4 db = new FrikiTeamBDEntities4();

        // GET: api/Evento_Usuario_Codigo
        public IQueryable<Evento_Usuario_Codigo> GetEvento_Usuario_Codigo()
        {
            return db.Evento_Usuario_Codigo;
        }

        // GET: api/Evento_Usuario_Codigo/5
        [ResponseType(typeof(Evento_Usuario_Codigo))]
        public IHttpActionResult GetEvento_Usuario_Codigo(int id)
        {
            Evento_Usuario_Codigo evento_Usuario_Codigo = db.Evento_Usuario_Codigo.Find(id);
            if (evento_Usuario_Codigo == null)
            {
                return NotFound();
            }

            return Ok(evento_Usuario_Codigo);
        }

        // PUT: api/Evento_Usuario_Codigo/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEvento_Usuario_Codigo(int id, Evento_Usuario_Codigo evento_Usuario_Codigo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != evento_Usuario_Codigo.IEUC)
            {
                return BadRequest();
            }

            db.Entry(evento_Usuario_Codigo).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Evento_Usuario_CodigoExists(id))
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

        // POST: api/Evento_Usuario_Codigo
        [ResponseType(typeof(Evento_Usuario_Codigo))]
        public IHttpActionResult PostEvento_Usuario_Codigo(Evento_Usuario_Codigo evento_Usuario_Codigo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Evento_Usuario_Codigo.Add(evento_Usuario_Codigo);

            try
            {
                db.SaveChanges();
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
            if (evento_Usuario_Codigo == null)
            {
                return NotFound();
            }

            db.Evento_Usuario_Codigo.Remove(evento_Usuario_Codigo);
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