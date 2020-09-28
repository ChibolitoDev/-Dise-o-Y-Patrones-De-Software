using System.Collections.Generic;
using FrikiTeamWebApp.Models;
using FrikiTeamWebApp.Repositorys;

namespace FrikiTeamWebApp.Services.Implementacion
{
    public class ClienteService : IClienteService
    {
        private IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository clienteRepository)
        {
            this._clienteRepository=clienteRepository;
        }
        
        public bool save(Cliente entity)
        {
            return _clienteRepository.save(entity);
        }

        public bool Update(Cliente entity)
        {
            return _clienteRepository.Update(entity);
        }

        public bool Delete(int id)
        {
            return _clienteRepository.Delete(id);
        }

        public IEnumerable<Cliente> GetAll()
        {
            return _clienteRepository.GetAll();
        }

        public Cliente GetById(int id)
        {
            return _clienteRepository.GetById(id);
        }
    }
}