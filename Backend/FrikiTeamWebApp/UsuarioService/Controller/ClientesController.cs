using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;
using FrikiTeamWebApp.Models;
using FrikiTeamWebApp.UsuarioService.Repository;
using FrikiTeamWebApp.UsuarioService.Service.Implementacion;

namespace FrikiTeamWebApp.UsuarioService.Controller
{
    public class ClientesController : ApiController
    {
        private FrikiTeamBDEntities4 db = new FrikiTeamBDEntities4();
        private readonly ClienteService _clienteservice ;

        public ClientesController()
        {
            this._clienteservice  = new ClienteService(db);
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



        [ResponseType(typeof(Cliente))]
        public IHttpActionResult AgregarCliente(Cliente cliente)
        {
            return Ok(_clienteservice.save(cliente));
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