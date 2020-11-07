using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using FrikiTeamWebApp.Models;

namespace FrikiTeamWebApp.UsuarioService.Repository.Implementacion
{
    public class ClienteRepository : IClienteRepository
    {
        private FrikiTeamBDEntities4 context;
        public ClienteRepository (FrikiTeamBDEntities4 context) {
            this.context = context;
        }
        public bool save(Cliente entity)
        {
            try
            { context.Set<Cliente>().Add(entity); 
            }
            catch (System.Exception)
            {
                return false;
            }
            return true;
        }

        public bool Update(Cliente entity)
        {
            try
            {
                context.Entry(entity).State = EntityState.Modified;
            }
            catch (System.Exception)
            {
                return false;
            }
            return true;
        }

            public bool Delete(int id)
        {
            var result = new Cliente();
            try
            {
                result = context.Cliente.Single(x => x.IDCliente == id);
                context.Cliente.Remove(result);
            }
            catch (System.Exception)
            {
                return false;
            }

            return true;
            
        }

        public IEnumerable<Cliente> GetAll()
        {
            var result = new List<Cliente>();
            try
            {
                result = context.Cliente.ToList();
            }
            catch(System.Exception)
            {

            }
            return result;              }

        public Cliente GetById(int id)
        {
            var result = new Cliente();
            try  
            {
                result = context.Cliente.Single(x => x.IDCliente == id);
            }
            catch (System.Exception)
            {

            }
            return result;        }
    }
}