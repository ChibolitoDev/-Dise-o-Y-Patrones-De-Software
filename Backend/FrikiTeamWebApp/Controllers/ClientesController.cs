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
using FrikiTeamWebApp.Repositorys;

namespace FrikiTeamWebApp.Controllers
{
    public class ClientesController : ApiController
    {
        private FrikiTeamBDEntities4 db = new FrikiTeamBDEntities4();
        private readonly IClienteRepository _clienteservice;

        public ClientesController(IClienteRepository servicio)
        {
            this._clienteservice = servicio;
        }

        // GET: api/Clientes
        public IEnumerable<Cliente> GetCliente()
        {
            return _clienteservice.GetAll();
        }

        // GET: api/Clientes/5
        [ResponseType(typeof(Cliente))]
        public IHttpActionResult GetCliente(int id)
        {
            return Ok(_clienteservice.GetById(id));
        }

        // DELETE: api/Clientes/5
        [ResponseType(typeof(Cliente))]
        public IHttpActionResult DeleteCliente(int id)
        {
            Cliente cliente = _clienteservice.GetById(id);
            if (cliente == null)
            {
                return NotFound();
            }

            _clienteservice.Delete(id);
            db.SaveChanges();

            return Ok(cliente);
        }

        [ResponseType(typeof(Cliente))]
        public IHttpActionResult AgregarCliente(Cliente cliente)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _clienteservice.save(cliente);
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ClienteExists(cliente.IDCliente))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = cliente.IDCliente }, cliente);
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ClienteExists(int id)
        {
            return db.Cliente.Count(e => e.IDCliente == id) > 0;
        }
    }
}