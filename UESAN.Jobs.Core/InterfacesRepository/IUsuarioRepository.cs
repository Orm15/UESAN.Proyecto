using UESAN.Proyecto.Core.entities;

namespace UESAN.proyecto.Infrastructure.repository
{
	public interface IUsuarioRepository
	{
		Task<bool> delete(int id);
		Task<IEnumerable<Usuarios>> getAll();
		Task<int> Insert(Usuarios u);
		Task<bool> IsEmailRegistered(string email);
		Task<Usuarios> SigIn(string username);
		Task<bool> update(Usuarios u);
	}
}