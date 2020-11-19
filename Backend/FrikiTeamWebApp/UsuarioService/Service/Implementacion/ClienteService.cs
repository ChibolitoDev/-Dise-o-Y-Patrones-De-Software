using System.Collections.Generic;
using FrikiTeamWebApp.Models;
using FrikiTeamWebApp.UsuarioService.Repository.Implementacion;

namespace FrikiTeamWebApp.UsuarioService.Service.Implementacion
{
    public class ClienteService : IClienteService
    {
        private ClienteRepository _clienteRepository;
        private FrikiTeamBDEntities4 db;

        public ClienteService(FrikiTeamBDEntities4 db)
        {
            this.db = db;
            this._clienteRepository= new ClienteRepository(db);
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