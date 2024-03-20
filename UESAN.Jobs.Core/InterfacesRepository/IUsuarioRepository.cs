using UESAN.Proyecto.Core.entities;

namespace UESAN.Proyecto.Core.InterfacesRepository
{
	public interface IUsuarioRepository
	{
		Task<bool> delete(int id);
		Task<IEnumerable<Usuarios>> getAll(string filtro);
		Task<Usuarios> Insert(Usuarios u);
		Task<bool> IsEmailRegistered(string email);
		Task<Usuarios> SigIn(string contra, string password);
		Task<bool> update(Usuarios u);
		Task<Usuarios> SigInSalt(string correo, string contra);
		Task<Usuarios> getById(int id);
	}
}