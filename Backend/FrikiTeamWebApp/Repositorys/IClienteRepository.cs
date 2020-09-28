using FrikiTeamWebApp.Models;

namespace FrikiTeamWebApp.Repositorys
{
    public interface IClienteRepository : IRepository<Cliente>
    {
        Cliente GetById(int id);

    }
}