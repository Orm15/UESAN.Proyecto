using UESAN.Proyecto.Core.DTO;

namespace UESAN.Proyecto.Core.InterfacesServices
{
    public interface IServicioEdicionVideoService
    {
        Task<bool> delete(int id);
        Task<IEnumerable<ServicioEdicionVideoDTO>> GetAll();
        Task<ServicioEdicionVideoDTO> getbYId(int id);
        Task<IEnumerable<ServicioEdicionVideoDTO>> GetBYIdEvento(int id);
        Task<IEnumerable<ServicioEdicionVideoDTO>> GetBYIdUsuario(int id);
        Task<int> InsertServicioEdicion(ServicioEdicionVideoInsertDTO x);
        Task<bool> update(ServicioEdicionVideoUpdateDTO servicioEdicion);
    }
}