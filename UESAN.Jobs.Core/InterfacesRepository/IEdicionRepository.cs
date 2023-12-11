using UESAN.Proyecto.Core.entities;

namespace UESAN.Proyecto.Core.InterfacesRepository
{
	public interface IEdicionRepository
	{
		Task<bool> delete(int id);
		Task<IEnumerable<Edicion>> getAll();
		Task<Edicion> GetByIdEdicion(int id);
		Task<Edicion> GetByIdVideo(int id);
		Task<Edicion> Insert(Edicion sv);
		Task<bool> update(Edicion sv);

		Task<DateTime?> getFechaEventoByIdEdicion(int id);
	}
}