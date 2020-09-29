using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using FrikiTeamWebApp.Models;
using Microsoft.Ajax.Utilities;

namespace FrikiTeamWebApp.Repositorys.Implementacion
{
    public class EventoRepository : IEventoRepository
    {
        private FrikiTeamBDEntities4 context;
        public EventoRepository (FrikiTeamBDEntities4 context) {
            this.context = context;
        }
        public bool save(Evento entity)
        {
            try
            {
                context.Set<Evento>().Add(entity);
                context.SaveChanges();
            }
            catch (System.Exception)
            {
                return false;
            }

            return true;
        }

        public bool Update(Evento entity)
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
            var result = new Evento();
            try
            {
                result = context.Evento.Single(x => x.IDEvento == id);
                context.Evento.Remove(result);
            }
            catch (System.Exception)
            {
                return false;
            }

            return true;        }

        public IEnumerable<Evento> GetAll()
        {
            var result = new List<Evento>();
            try
            {
                result = context.Evento.ToList();
            }
            catch(System.Exception)
            {

            }
            return result;         }

        public List<Evento> FindByName(string Name)
        {
            var result = new List<Evento>();
            try  
            {
                foreach (Evento evento in context.Evento.ToList())
                    if (evento.NEvento==Name)
                    {
                        result.Add(evento);
                    }
            }
            catch (System.Exception)
            {
                throw  new Exception("No se encontraron servicios de esa categoria");
                return result;
            }
            return result;
            
        }

        public List<Evento> FindByDireccion(string Direccion)
        {
            var result = new List<Evento>();
            try  
            {
                foreach (Evento evento in context.Evento.ToList())
                    if (evento.NumeroCasa.Calle.NCalle==Direccion)
                    {
                        result.Add(evento);
                    }
            }
            catch (System.Exception)
            {
                throw  new Exception("No se encontraron servicios de esa direccion");
            }
            return result;
            
        }

        public List<Evento> FindByDistrito(string Distrito)
        {
            var result = new List<Evento>();
            try  
            {
                foreach (Evento evento in context.Evento.ToList())
                    if (evento.NumeroCasa.Calle.Distrito.NDistrito==Distrito)
                    {
                        result.Add(evento);
                    }
            }
            catch (System.Exception)
            {
                throw  new Exception("No se encontraron servicios de ese distrito");
            }
            return result;        }
    }
}