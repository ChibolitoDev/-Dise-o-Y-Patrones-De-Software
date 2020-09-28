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
    public class OrganizadorsController : ApiController
    {
        private FrikiTeamBDEntities4 db = new FrikiTeamBDEntities4();

        // GET: api/Organizadors
        public IQueryable<Organizador> GetOrganizador()
        {
            return db.Organizador;
        }

        // GET: api/Organizadors/5
        [ResponseType(typeof(Organizador))]
        public IHttpActionResult GetOrganizador(int id)
        {
            Organizador organizador = db.Organizador.Find(id);
            if (organizador == null)
            {
                return NotFound();
            }

            return Ok(organizador);
        }

        // PUT: api/Organizadors/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutOrganizador(int id, Organizador organizador)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != organizador.IDOrganizador)
            {
                return BadRequest();
            }

            db.Entry(organizador).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrganizadorExists(id))
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

        // POST: api/Organizadors
        [ResponseType(typeof(Organizador))]
        public IHttpActionResult PostOrganizador(Organizador organizador)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Organizador.Add(organizador);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (OrganizadorExists(organizador.IDOrganizador))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = organizador.IDOrganizador }, organizador);
        }

        // DELETE: api/Organizadors/5
        [ResponseType(typeof(Organizador))]
        public IHttpActionResult DeleteOrganizador(int id)
        {
            Organizador organizador = db.Organizador.Find(id);
            if (organizador == null)
            {
                return NotFound();
            }

            db.Organizador.Remove(organizador);
            db.SaveChanges();

            return Ok(organizador);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool OrganizadorExists(int id)
        {
            return db.Organizador.Count(e => e.IDOrganizador == id) > 0;
        }
    }
}