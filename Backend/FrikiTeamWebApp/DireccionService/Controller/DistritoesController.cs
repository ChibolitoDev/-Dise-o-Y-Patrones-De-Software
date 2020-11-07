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

namespace FrikiTeamWebApp.DireccionService.Controllers
{
    public class DistritoesController : ApiController
    {
        private FrikiTeamBDEntities4 db = new FrikiTeamBDEntities4();

        // GET: api/Distritoes
        public IQueryable<Distrito> GetDistrito()
        {
            return db.Distrito;
        }

        // GET: api/Distritoes/5
        [ResponseType(typeof(Distrito))]
        public IHttpActionResult GetDistrito(int id)
        {
            Distrito distrito = db.Distrito.Find(id);
            if (distrito == null)
            {
                return NotFound();
            }

            return Ok(distrito);
        }

        // PUT: api/Distritoes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDistrito(int id, Distrito distrito)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != distrito.IDDistrito)
            {
                return BadRequest();
            }

            db.Entry(distrito).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DistritoExists(id))
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

        // POST: api/Distritoes
        [ResponseType(typeof(Distrito))]
        public IHttpActionResult PostDistrito(Distrito distrito)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Distrito.Add(distrito);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (DistritoExists(distrito.IDDistrito))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = distrito.IDDistrito }, distrito);
        }

        // DELETE: api/Distritoes/5
        [ResponseType(typeof(Distrito))]
        public IHttpActionResult DeleteDistrito(int id)
        {
            Distrito distrito = db.Distrito.Find(id);
            if (distrito == null)
            {
                return NotFound();
            }

            db.Distrito.Remove(distrito);
            db.SaveChanges();

            return Ok(distrito);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DistritoExists(int id)
        {
            return db.Distrito.Count(e => e.IDDistrito == id) > 0;
        }
    }
}