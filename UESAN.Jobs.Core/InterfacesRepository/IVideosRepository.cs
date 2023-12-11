using UESAN.Proyecto.Core.entities;

namespace UESAN.Proyecto.Core.InterfacesRepository
{
	public interface IVideosRepository
	{
		Task<bool> delete(int id);
		Task<IEnumerable<Videos>> getAll();
		Task<Videos> getById(int id);
		Task<IEnumerable<Videos>> getByIdEvento(int id);
		Task<IEnumerable<Videos>> getByIdServicio(int id);
		Task<string> getLink(int id);
		Task<Videos> Insert(Videos sv);
		Task<bool> update(Videos sv);
		Task<bool> CambiarEstadoEdicion(int id);
	}
}