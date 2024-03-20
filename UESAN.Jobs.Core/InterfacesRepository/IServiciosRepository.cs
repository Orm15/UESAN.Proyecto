using UESAN.Proyecto.Core.entities;

namespace UESAN.Proyecto.Core.InterfacesRepository
{
	public interface IServiciosRepository
	{
		Task<bool> delete(int id);
		Task<IEnumerable<Servicios>> getAll();
		Task<IEnumerable<Servicios>> getAllByIdEvento(int id);
		Task<Servicios> getById(int id);
		Task<bool> update(Servicios e);

		Task<int> insertServicio(Servicios servicios);
	}
}