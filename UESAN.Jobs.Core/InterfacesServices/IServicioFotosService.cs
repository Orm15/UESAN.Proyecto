using UESAN.Proyecto.Core.DTO;

namespace UESAN.Proyecto.Core.InterfacesServices
{
    public interface IServicioFotosService
    {
        Task<int> Create(ServicioFotosDTO servFotDTO);
        Task<IEnumerable<ServicioFotosDTO>> getAll();
        Task<ServicioFotosDTO> getById(int id);
        Task<IEnumerable<ServicioFotosDTO>> getBySId(int id);
        Task<bool> Update(ServicioFotosDTO servFotDTO);
    }
}