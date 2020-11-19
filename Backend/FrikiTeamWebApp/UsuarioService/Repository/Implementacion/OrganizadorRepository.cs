using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using FrikiTeamWebApp.Models;
using FrikiTeamWebApp.Repositorys;

namespace FrikiTeamWebApp.UsuarioService.Repository.Implementacion
{
    public class OrganizadorRepository : IOrganizadorRepository
    {
        private FrikiTeamBDEntities4 context;
        public OrganizadorRepository (FrikiTeamBDEntities4 context) {
            this.context = context;
        }
        public bool save(Organizador entity)
        {
            try
            {
                context.Set<Organizador>().Add(entity);
            }
            catch (System.Exception)
            {
                return false;
            }
            return true;        }

        public bool Update(Organizador entity)
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
            var result = new Organizador();
            try
            {
                result = context.Organizador.Single(x => x.IDOrganizador == id);
                context.Organizador.Remove(result);            }
            catch (System.Exception)
            {
                return false;
            }

            return true;        }

        public IEnumerable<Organizador> GetAll()
        {
            var result = new List<Organizador>();
            try
            {
                result = context.Organizador.ToList();
            }
            catch(System.Exception)
            {

            }
            return result;
            
        }

        public Organizador GetById(int id)
        {
            var result = new Organizador();
            try  
            {
                result = context.Organizador.Single(x => x.IDOrganizador == id);
            }
            catch (System.Exception)
            {

            }
            return result;
            
        }

        public bool Calificar(int id,int calificacion)
        {
            var result = new Organizador();
            try
            {
                result = context.Organizador.Single(x => x.IDOrganizador == id);
                result.Calificacion += calificacion;
                Update(result);
            }
            catch (System.Exception)
            {
                return false;
            }

            return true;
        }
    }
}