using UESAN.Proyecto.Core.entities;

namespace UESAN.Proyecto.Core.InterfacesRepository
{
	public interface IEventoRepository
	{
		Task<bool> CambiarEstado(int idE);
		Task<bool> delete(int id);
		Task<IEnumerable<Eventos>> getAll();
		Task<IEnumerable<Eventos>> getEventosByEstado(string cadena);
		Task<Eventos> getEventosById(int id);
		Task<bool> insertEvento(Eventos eventos);
		Task<bool> update(Eventos e);
	}
}