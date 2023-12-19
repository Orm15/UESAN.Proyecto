using UESAN.Proyecto.Core.DTO;

namespace UESAN.Proyecto.Core.InterfacesServices
{
    public interface IEscenaVideoService
    {
        Task<bool> delete(int id);
        Task<EscenasVideoDTO> GetAllById(int id);
        Task<IEnumerable<EscenasVideoDTO>> GetAllByIdServicioEdicion(int id);
        Task<bool> InsertCC(EscenasVideoInsertDTO escenasVideoInsertDTO);
        Task<bool> update(EscenasVideoUpdateDTO escenasVideoUpdate);
    }
}