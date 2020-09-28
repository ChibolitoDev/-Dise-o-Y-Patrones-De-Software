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
    public class CodigoEventoesController : ApiController
    {
        private FrikiTeamBDEntities4 db = new FrikiTeamBDEntities4();

        // GET: api/CodigoEventoes
        public IQueryable<CodigoEvento> GetCodigoEvento()
        {
            return db.CodigoEvento;
        }

        // GET: api/CodigoEventoes/5
        [ResponseType(typeof(CodigoEvento))]
        public IHttpActionResult GetCodigoEvento(int id)
        {
            CodigoEvento codigoEvento = db.CodigoEvento.Find(id);
            if (codigoEvento == null)
            {
                return NotFound();
            }

            return Ok(codigoEvento);
        }

        // PUT: api/CodigoEventoes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCodigoEvento(int id, CodigoEvento codigoEvento)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != codigoEvento.IDCodigo)
            {
                return BadRequest();
            }

            db.Entry(codigoEvento).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CodigoEventoExists(id))
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

        // POST: api/CodigoEventoes
        [ResponseType(typeof(CodigoEvento))]
        public IHttpActionResult PostCodigoEvento(CodigoEvento codigoEvento)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CodigoEvento.Add(codigoEvento);

            try
            {
                db.SaveChanges();
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

        // DELETE: api/CodigoEventoes/5
        [ResponseType(typeof(CodigoEvento))]
        public IHttpActionResult DeleteCodigoEvento(int id)
        {
            CodigoEvento codigoEvento = db.CodigoEvento.Find(id);
            if (codigoEvento == null)
            {
                return NotFound();
            }

            db.CodigoEvento.Remove(codigoEvento);
            db.SaveChanges();

            return Ok(codigoEvento);
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