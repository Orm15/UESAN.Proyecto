using UESAN.Proyecto.Core.entities;
using UESAN.Proyecto.Core.Utilidades;

namespace UESAN.Proyecto.Core.InterfacesServices
{
	public interface IJWTFactory
	{
		JWTSettings _settings { get; }

		string GenerateJWToken(Usuarios user);
	}
}