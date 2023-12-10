using UESAN.Proyecto.Core.DTO;

namespace UESAN.Proyecto.Core.InterfacesServices
{
    public interface IServicioService
    {
        Task<bool> delete(int id);
        Task<IEnumerable<ServicioDTO>> GetAll();
        Task<IEnumerable<ServicioDTO>> GetAllByIdEvento(int id);
        Task<ServicioDTO> GetById(int id);
        Task<bool> update(ServicioUpdateDTO servicioUpdateDTO);
        Task<int> InsertServicio(ServicioInsertDTO servicioInsertDTO);

	}
}