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
		Task<int> insertEvento(Eventos eventos);
		Task<bool> update(Eventos e);

		Task<IEnumerable<Eventos>> getEventosByUsuario(int id);

		Task<IEnumerable<Eventos>> getAllByIdMismaArea(string area);
		Task<IEnumerable<Eventos>> GetEventosByUsuarioCreadorOrVizualizador(int id, string area);
	}
}