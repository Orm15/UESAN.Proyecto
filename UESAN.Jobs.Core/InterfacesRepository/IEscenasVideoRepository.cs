using UESAN.Proyecto.Core.entities;

namespace UESAN.Proyecto.Core.InterfacesRepository
{
	public interface IEscenasVideoRepository
	{
		Task<bool> delete(int id);
		Task<IEnumerable<EscenasVideo>> getAll();
		Task<EscenasVideo> getById(int id);
		Task<IEnumerable<EscenasVideo>> getByIdServicioEdicion(int id);
		Task<EscenasVideo> Insert(EscenasVideo sv);
		Task<bool> update(EscenasVideo sv);
	}
}