using FrikiTeamWebApp.Models;

namespace FrikiTeamWebApp.Services
{
    public interface IClienteService : IService<Cliente>
    {
         Cliente GetById(int id);

    }
}