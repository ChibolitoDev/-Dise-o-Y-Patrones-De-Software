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
using FrikiTeamWebApp.Services;
using FrikiTeamWebApp.Services.Implementacion;
using FrikiTeamWebApp.UsuarioService.Service;
using FrikiTeamWebApp.UsuarioService.Service.Implementacion;

namespace FrikiTeamWebApp.UsuarioService.Controller
{
    public class OrganizadorsController : ApiController
    {
        private FrikiTeamBDEntities4 db = new FrikiTeamBDEntities4();
        private readonly IOrganizadorService _organizadorservice;

        public OrganizadorsController(OrganizadorService servicio)
        {
            this._organizadorservice = servicio;
        }

        // GET: api/Organizadors
        [HttpGet]
        public IEnumerable<Organizador> GetAction()
        {
            return _organizadorservice.GetAll();
        }

        // GET: api/Organizadors/5
        [ResponseType(typeof(Organizador))]
        public IHttpActionResult GetOrganizador(int id)
        {
            Organizador organizador = _organizadorservice.GetById(id);
            if (organizador == null)
            {
                return NotFound();
            }

            return Ok(organizador);
        }


        // POST: api/Organizadors
        [ResponseType(typeof(Organizador))]
        public IHttpActionResult Calificar(int id, int calificacion)
        {

            return Ok(_organizadorservice.Calificar(id, calificacion));
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

            _organizadorservice.save(organizador);
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


        private bool OrganizadorExists(int id)
        {
            return db.Organizador.Count(e => e.IDOrganizador == id) > 0;
        }
    }
}