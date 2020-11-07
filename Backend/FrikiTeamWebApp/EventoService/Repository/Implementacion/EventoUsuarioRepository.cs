using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using FrikiTeamWebApp.Models;


namespace FrikiTeamWebApp.EventoService.Repository.Implementacion
{
    public class EventoUsuarioRepository : IEventoUsuarioRepository
    {
        private FrikiTeamBDEntities4 context;
        public EventoUsuarioRepository (FrikiTeamBDEntities4 context) {
            this.context = context;
        }

        public bool save(Evento_Usuario entity)
        {
            try
            {
                context.Set<Evento_Usuario>().Add(entity);
                context.SaveChanges();
            }
            catch (System.Exception)
            {
                return false;
            }

            return true;        }

        public bool Update(Evento_Usuario entity)
        {
            try
            {
                context.Entry(entity).State = EntityState.Modified;
            }
            catch (System.Exception)
            {
                return false;
            }
            
            return true;        }

        public bool Delete(int id)
        {
            var result = new Evento_Usuario();
            try
            {
                result = context.Evento_Usuario.Single(x => x.IDEvento_Usuario == id);
                context.Evento_Usuario.Remove(result);
            }
            catch (System.Exception)
            {
                return false;
            }

            return true;        }

        public IEnumerable<Evento_Usuario> GetAll()
        {
            var result = new List<Evento_Usuario>();
            try
            {
                result = context.Evento_Usuario.ToList();
            }
            catch(System.Exception)
            {

            }
            return result;         }
    }
}