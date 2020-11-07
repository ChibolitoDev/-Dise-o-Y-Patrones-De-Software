using System.Collections.Generic;
using FrikiTeamWebApp.DireccionService.Repository;
using FrikiTeamWebApp.Models;
using FrikiTeamWebApp.Repositorys;
using FrikiTeamWebApp.Services;

namespace FrikiTeamWebApp.DireccionService.Service.Implementacion
{
    public class NumeroCasaService : INumeroCasaService
    {
        private INumeroCasaRepository _casaRepository;

        public NumeroCasaService(INumeroCasaRepository usuarioRepository)
        {
            this._casaRepository=usuarioRepository;
        }
        public bool save(NumeroCasa entity)
        {
            return _casaRepository.save(entity);
        }

        public bool Update(NumeroCasa entity)
        {
            return _casaRepository.Update(entity);
        }

        public bool Delete(int id)
        {
            return _casaRepository.Delete(id);
        }

        public IEnumerable<NumeroCasa> GetAll()
        {
            return _casaRepository.GetAll();
        }

    }
}