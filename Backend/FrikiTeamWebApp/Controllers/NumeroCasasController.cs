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
    public class NumeroCasasController : ApiController
    {
        private FrikiTeamBDEntities4 db = new FrikiTeamBDEntities4();

        // GET: api/NumeroCasas
        public IQueryable<NumeroCasa> GetNumeroCasa()
        {
            return db.NumeroCasa;
        }

        // GET: api/NumeroCasas/5
        [ResponseType(typeof(NumeroCasa))]
        public IHttpActionResult GetNumeroCasa(int id)
        {
            NumeroCasa numeroCasa = db.NumeroCasa.Find(id);
            if (numeroCasa == null)
            {
                return NotFound();
            }

            return Ok(numeroCasa);
        }

        // PUT: api/NumeroCasas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutNumeroCasa(int id, NumeroCasa numeroCasa)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != numeroCasa.IDNumero)
            {
                return BadRequest();
            }

            db.Entry(numeroCasa).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NumeroCasaExists(id))
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

        // POST: api/NumeroCasas
        [ResponseType(typeof(NumeroCasa))]
        public IHttpActionResult PostNumeroCasa(NumeroCasa numeroCasa)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.NumeroCasa.Add(numeroCasa);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (NumeroCasaExists(numeroCasa.IDNumero))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = numeroCasa.IDNumero }, numeroCasa);
        }

        // DELETE: api/NumeroCasas/5
        [ResponseType(typeof(NumeroCasa))]
        public IHttpActionResult DeleteNumeroCasa(int id)
        {
            NumeroCasa numeroCasa = db.NumeroCasa.Find(id);
            if (numeroCasa == null)
            {
                return NotFound();
            }

            db.NumeroCasa.Remove(numeroCasa);
            db.SaveChanges();

            return Ok(numeroCasa);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool NumeroCasaExists(int id)
        {
            return db.NumeroCasa.Count(e => e.IDNumero == id) > 0;
        }
    }
}