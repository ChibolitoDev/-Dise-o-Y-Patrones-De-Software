using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using FrikiTeamWebApp.Models;


namespace FrikiTeamWebApp.DireccionService.Repository.Implementacion
{
    public class DistritoRepository :IDistritoRepository
    {
        private FrikiTeamBDEntities4 context;
        public DistritoRepository (FrikiTeamBDEntities4 context) {
            this.context = context;
        }
        public bool save(Distrito entity)
        {
            try
            {
                context.Set<Distrito>().Add(entity);
                context.SaveChanges();
            }
            catch (System.Exception)
            {
                return false;
            }

            return true;
            
        }

        public bool Update(Distrito entity)
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
            var result = new Distrito();
            try
            {
                result = context.Distrito.Single(x=>x.IDDistrito == id);
                context.Distrito.Remove(result);
            }
            catch (System.Exception)
            {
                return false;
            }

            return true;
            
        }

        public IEnumerable<Distrito> GetAll()
        {
            var result = new List<Distrito>();
            try
            {
                result = context.Distrito.ToList();
            }
            catch(System.Exception)
            {

            }
            return result;                }
    }
}