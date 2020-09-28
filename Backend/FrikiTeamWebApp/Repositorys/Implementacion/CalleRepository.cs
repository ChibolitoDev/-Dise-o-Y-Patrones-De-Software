using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using FrikiTeamWebApp.Models;

namespace FrikiTeamWebApp.Repositorys.Implementacion
{
    public class CalleRepository: ICalleRepository
    {
        private FrikiTeamBDEntities4 context;
        public CalleRepository (FrikiTeamBDEntities4 context) {
            this.context = context;
        }
        public bool save(Calle entity)
        {
            try
            {
                context.Set<Calle>().Add(entity);
                context.SaveChanges();
            }
            catch (System.Exception)
            {
                return false;
            }

            return true;        }

        public bool Update(Calle entity)
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
            var result = new Calle();
            try
            {
                result = context.Calle.Single(x => x.IDCalle == id);
                context.Calle.Remove(result);
            }
            catch (System.Exception)
            {
                return false;
            }

            return true;        }

        public IEnumerable<Calle> GetAll()
        {
            var result = new List<Calle>();
            try
            {
                result = context.Calle.ToList();
            }
            catch(System.Exception)
            {

            }
            return result;
            
        }
    }
}