using UESAN.Proyecto.Core.entities;

namespace UESAN.Proyecto.Core.InterfacesRepository
{
	public interface IEventoRepository
	{
		Task<bool> CambiarEstado(int idE);
		Task<IEnumerable<Eventos>> getAll();
		Task<bool> insertEvento(Eventos eventos);
		Task<IEnumerable<Eventos>> getEventosByEstado(string cadena);
		Task<Eventos> getEventosById(int id);
		Task<bool> delete(int id);
		Task<bool> update(Eventos e);
	}
}