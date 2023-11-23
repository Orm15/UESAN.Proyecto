using UESAN.Proyecto.Core.entities;

namespace UESAN.Proyecto.Core.InterfacesRepository
{
	public interface IInteraccionRepository
	{
		Task<IEnumerable<Interaccion>> getall();
		Task<IEnumerable<Interaccion>> getByIdEvento(int id);
		Task<Interaccion> getByIdInteraccion(int id);
		Task<Interaccion> GetInteraccioncreadorByIdEvento(int id);
		Task<IEnumerable<Interaccion>> getInteraccionesByCreadorVisualizador(int idUsuario);
		Task<IEnumerable<Interaccion>> GetInteraccionesbyIdUsuarioCreador(int id);
		Task<IEnumerable<Interaccion>> GetInteraccionesbyIdUsuarioVisualizador(int id);
		Task<IEnumerable<Interaccion>> GetInteraccionesVisualizacionByIdEvento(int id);
		Task<bool> interaccionInsert(Interaccion interaccion);
	}
}