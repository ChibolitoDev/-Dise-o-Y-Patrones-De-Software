﻿using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using FrikiTeamWebApp.Models;


namespace FrikiTeamWebApp.EventoService.Repository.Implementacion
{
    public class CodigoEventoRepository : ICodigoEvento
    {
        private FrikiTeamBDEntities4 context;
        public CodigoEventoRepository (FrikiTeamBDEntities4 context) {
            this.context = context;
        }
        public bool save(CodigoEvento entity)
        {
            try
            {
                context.Set<CodigoEvento>().Add(entity);
            }
            catch (System.Exception)
            {
                return false;
            }

            return true;          }

        public bool Update(CodigoEvento entity)
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
            var result = new CodigoEvento();
            try
            {
                result = context.CodigoEvento.Single(x => x.IDCodigo == id);
                context.CodigoEvento.Remove(result);
            }
            catch (System.Exception)
            {
                return false;
            }

            return true;        }

        public IEnumerable<CodigoEvento> GetAll()
        {
            var result = new List<CodigoEvento>();
            try
            {
                result = context.CodigoEvento.ToList();
            }
            catch(System.Exception)
            {

            }
            return result;
        }
    }
}