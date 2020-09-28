using System.Collections.Generic;
using System.Linq;
using FrikiTeamWebApp.Models;

namespace FrikiTeamWebApp.Repositorys.Implementacion
{
    public class EventoUsuarioCodigoRepository : IEventoUsuarioCodigoRepository
    {
        private FrikiTeamBDEntities4 context;
        public EventoUsuarioCodigoRepository (FrikiTeamBDEntities4 context) {
            this.context = context;
        }
        public bool save(Evento_Usuario_Codigo entity)
        {
            try
            {
                context.Set<Evento_Usuario_Codigo>().Add(entity);
                context.SaveChanges();
            }
            catch (System.Exception)
            {
                return false;
            }

            return true;        }

        public bool Update(Evento_Usuario_Codigo entity)
        {
            throw new System.NotImplementedException();
        }

        public bool Delete(int id)
        {
            var result = new Evento_Usuario_Codigo();
            try
            {
                result = context.Evento_Usuario_Codigo.Single(x => x.IEUC == id);
                context.Evento_Usuario_Codigo.Remove(result);
            }
            catch (System.Exception)
            {
                return false;
            }

            return true;        }

        public IEnumerable<Evento_Usuario_Codigo> GetAll()
        {
            var result = new List<Evento_Usuario_Codigo>();
            try
            {
                result = context.Evento_Usuario_Codigo.ToList();
            }
            catch(System.Exception)
            {

            }
            return result;
            
        }
    }
}