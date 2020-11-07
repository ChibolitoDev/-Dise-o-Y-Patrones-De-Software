using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using FrikiTeamWebApp.Models;


namespace FrikiTeamWebApp.DireccionService.Repository.Implementacion
{
    public class NumeroCasaRepository : INumeroCasaRepository
    {
        private FrikiTeamBDEntities4 context;
        public NumeroCasaRepository (FrikiTeamBDEntities4 context) {
            this.context = context;
        }
        public bool save(NumeroCasa entity)
        {
            try
            {
                context.Set<NumeroCasa>().Add(entity);
                context.SaveChanges();
            }
            catch (System.Exception)
            {
                return false;
            }

            return true;        }

        public bool Update(NumeroCasa entity)
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
            var result = new NumeroCasa();
            try
            {
                result = context.NumeroCasa.Single(x => x.IDNumero == id);
                context.NumeroCasa.Remove(result);
            }
            catch (System.Exception)
            {
                return false;
            }

            return true;        }

        public IEnumerable<NumeroCasa> GetAll()
        {
            var result = new List<NumeroCasa>();
            try
            {
                result = context.NumeroCasa.ToList();
            }
            catch(System.Exception)
            {

            }
            return result;              }
    }
}