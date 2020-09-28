using System.Collections.Generic;
using FrikiTeamWebApp.Models;
using FrikiTeamWebApp.Repositorys;

namespace FrikiTeamWebApp.Services.Implementacion
{
    public class EventoUsuarioCodigoService:IEventoUsuarioCodigoService
    {
        private IEventoUsuarioCodigoRepository _eventoUsuarioCodigoRepository;

        public EventoUsuarioCodigoService(IEventoUsuarioCodigoRepository eventoUsuarioCodigoRepository)
        {
            this._eventoUsuarioCodigoRepository=eventoUsuarioCodigoRepository;
        }
        
        public bool save(Evento_Usuario_Codigo entity)
        {
            return _eventoUsuarioCodigoRepository.save(entity);
        }

        public bool Update(Evento_Usuario_Codigo entity)
        {
            return _eventoUsuarioCodigoRepository.Update(entity);
        }

        public bool Delete(int id)
        {
            return _eventoUsuarioCodigoRepository.Delete(id);
        }

        public IEnumerable<Evento_Usuario_Codigo> GetAll()
        {
            return _eventoUsuarioCodigoRepository.GetAll();
        }
        
    }
}
