using System.Collections.Generic;
using FrikiTeamWebApp.Models;

namespace FrikiTeamWebApp.Repositorys
{
    public interface IRepository<T>
    {
        bool save(T entity);
        bool Update(T entity);
        bool Delete(int id);
        IEnumerable<T> GetAll();
    }
}