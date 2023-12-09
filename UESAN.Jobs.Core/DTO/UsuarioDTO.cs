using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UESAN.Proyecto.Core.DTO
{
	public class UsuarioDTO
	{
		public int IdUsuario { get; set; }

		public string? Correo { get; set; }

		public string? Nombre { get; set; }

		public string? Area { get; set; }

		public string? Tipo { get; set; }

	}

	public class UsuarioCreateDTO
	{
		public string? Correo { get; set; }

		public string? Nombre { get; set; }

		public string? Area { get; set; }

		public string? Contra { get; set; }

	}

	public class UsuarioUpdateDTO
	{
		public int IdUsuario { get; set; }
		public string? Correo { get; set; }

		public string? Nombre { get; set; }

		public string? Area { get; set; }

		public string? Tipo { get; set; }

		public string? Estado { get; set; }

		public string? Contra { get; set; }

	}

	public class UsuarioAuthResponseDTO {

		public int IdUsuario { get; set; }

		public string? Tipo { get; set; }
	}

	public class UsuarioAuthenticationDTO
	{
		public string? Correo { get; set; }

		public string? Contra { get; set; }

	}



}
