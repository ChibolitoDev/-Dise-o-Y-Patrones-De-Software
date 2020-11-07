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

namespace FrikiTeamWebApp.DireccionService.Controller
{
    public class CallesController : ApiController
    {
        private FrikiTeamBDEntities4 db = new FrikiTeamBDEntities4();

        // GET: api/Calles
        public IQueryable<Calle> GetCalle()
        {
            return db.Calle;
        }

        // GET: api/Calles/5
        [ResponseType(typeof(Calle))]
        public IHttpActionResult GetCalle(int id)
        {
            Calle calle = db.Calle.Find(id);
            if (calle == null)
            {
                return NotFound();
            }

            return Ok(calle);
        }

        // PUT: api/Calles/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCalle(int id, Calle calle)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != calle.IDCalle)
            {
                return BadRequest();
            }

            db.Entry(calle).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CalleExists(id))
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

        // POST: api/Calles
        [ResponseType(typeof(Calle))]
        public IHttpActionResult PostCalle(Calle calle)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Calle.Add(calle);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (CalleExists(calle.IDCalle))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = calle.IDCalle }, calle);
        }

        // DELETE: api/Calles/5
        [ResponseType(typeof(Calle))]
        public IHttpActionResult DeleteCalle(int id)
        {
            Calle calle = db.Calle.Find(id);
            if (calle == null)
            {
                return NotFound();
            }

            db.Calle.Remove(calle);
            db.SaveChanges();

            return Ok(calle);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CalleExists(int id)
        {
            return db.Calle.Count(e => e.IDCalle == id) > 0;
        }
    }
}