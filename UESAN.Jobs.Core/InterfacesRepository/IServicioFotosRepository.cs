using UESAN.proyecto.Infrastructure.Models;

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