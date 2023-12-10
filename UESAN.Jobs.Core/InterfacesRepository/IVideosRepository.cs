using UESAN.Proyecto.Core.entities;

namespace UESAN.Proyecto.Core.InterfacesRepository
{
    public interface IVideosRepository
    {
        Task<IEnumerable<Videos>> getAll();
        Task<Videos> getById(int id);
        Task<IEnumerable<Videos>> getBySId(int id);
        Task<string> getLink(int id);
        Task<Videos> Insert(Videos sv);
        Task<bool> update(Videos sv);
    }
}