using System.Collections.Generic;
using FrikiTeamWebApp.Models;
using FrikiTeamWebApp.Repositorys;

namespace FrikiTeamWebApp.Services.Implementacion
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