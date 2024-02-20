using UESAN.Proyecto.Core.entities;

namespace UESAN.Proyecto.Core.InterfacesRepository
{
    public interface IStreamRepository
    {
        Task<bool> delete(int id);
        Task<IEnumerable<entities.Stream>> getAll();
        Task<entities.Stream> getById(int id);
        Task<entities.Stream> getByIdEvento(int id);
        Task<entities.Stream> getByIdServicio(int id);
        Task<entities.Stream> Insert(entities.Stream stream);
        Task<bool> update(entities.Stream stream);
    }
}