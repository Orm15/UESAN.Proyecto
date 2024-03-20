using UESAN.Proyecto.Core.entities;

namespace UESAN.Proyecto.Core.InterfacesRepository
{
	public interface IServicioEdicionVideoRepository
	{
		Task<bool> delete(int id);
		Task<IEnumerable<ServicioEdicionVideo>> getAll();
		Task<ServicioEdicionVideo> getById(int id);
		Task<IEnumerable<ServicioEdicionVideo>> getByIdEvento(int id);
		Task<IEnumerable<ServicioEdicionVideo>> getByIdUsuario(int id);
		Task<ServicioEdicionVideo> Insert(ServicioEdicionVideo sv);
		Task<bool> update(ServicioEdicionVideo sv);
	}
}