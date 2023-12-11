using UESAN.Proyecto.Core.entities;

namespace UESAN.Proyecto.Core.InterfacesRepository
{
    public interface IServicioFotosRepository
    {
        Task<IEnumerable<ServicioFotos>> getAll();
        Task<ServicioFotos> getById(int id);
        Task<IEnumerable<ServicioFotos>> getBySId(int id);
        Task<string> getLink(int id);
        Task<ServicioFotos> Insert(ServicioFotos sf);
        Task<bool> update(ServicioFotos sf);
    }
}