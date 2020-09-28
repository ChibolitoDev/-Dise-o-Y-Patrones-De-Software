using System.Collections.Generic;

namespace FrikiTeamWebApp.Services
{
    public interface IService<T>
    {
        bool save(T entity);
        bool Update(T entity);
        bool Delete(int id);
        IEnumerable<T> GetAll();
    }
}