using UESAN.Proyecto.Core.DTO;

namespace UESAN.Proyecto.Core.InterfacesServices
{
    public interface IEdicionService
    {
        Task<bool> delete(int id);
        Task<IEnumerable<EdicionDTO>> GetAll();
        Task<EdicionDTO> GetByIdEdicion(int idEdi);
        Task<EdicionDTO> GetByIdVideo(int idEdi);
        Task<bool> InsertEdicion(EdicionInsertDTO edicionInsertDTO);
        Task<bool> update(EdicionUpdateDTO edicionUpdateDTO);
    }
}