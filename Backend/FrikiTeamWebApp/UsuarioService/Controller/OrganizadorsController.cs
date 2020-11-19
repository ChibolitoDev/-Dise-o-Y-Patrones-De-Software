using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using FrikiTeamWebApp.Models;
using FrikiTeamWebApp.UsuarioService.Service;
using FrikiTeamWebApp.UsuarioService.Service.Implementacion;

namespace FrikiTeamWebApp.UsuarioService.Controller
{
    public class OrganizadorsController : ApiController
    {
        private FrikiTeamBDEntities4 db = new FrikiTeamBDEntities4();
        private readonly OrganizadorService _organizadorservice;

        public OrganizadorsController()
        {
            this._organizadorservice = new OrganizadorService(db);
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



        // POST: api/Organizadors
        [ResponseType(typeof(Organizador))]
        public IHttpActionResult PostOrganizador(Organizador organizador)
        {
            return Ok(_organizadorservice.save(organizador));
        }


        private bool OrganizadorExists(int id)
        {
            return db.Organizador.Count(e => e.IDOrganizador == id) > 0;
        }
    }
}