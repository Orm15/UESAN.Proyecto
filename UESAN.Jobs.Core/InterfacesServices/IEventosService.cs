using UESAN.Proyecto.Core.DTO;

namespace UESAN.Proyecto.Core.InterfacesServices
{
    public interface IEventosService
    {
        Task<bool> CambiarEstado(int id);
        Task<bool> delete(int id);
        Task<IEnumerable<EventosDTO>> EventosByEstado(string r);
        Task<IEnumerable<EventosDTO>> getAll();
        Task<IEnumerable<EventosDTO>> GetEventosByUsuarioCreador(int id);
        Task<IEnumerable<EventosDTO>> getEventosByUsuarioCreadorOrVizualizador(int id);
        Task<IEnumerable<EventosDTO>> getEventosByUsuarioVizualizador(int id);
        Task<bool> InsertEvento(EventoInsertDTO eventoInsertDTO);
        Task<bool> Update(EventoUpdateDTO eventoUpdateDTO);
    }
}