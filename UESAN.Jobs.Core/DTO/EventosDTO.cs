using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UESAN.Proyecto.Core.DTO
{
	public class EventosDTO
	{
		public int IdEvento { get; set; }

		public string? Nombre { get; set; }

		public string? Descripcion { get; set; }

		public DateTime? FechaEvento { get; set; }

		public string? HoraInicio { get; set; }

		public string? HoraFin { get; set; }

		public string? Lugar { get; set; }

		public string? Estado { get; set; }

		public DateTime? FechaCreacion { get; set; }

		public string? MomentosImportantes { get; set; }

		public int? CantidadInvitados { get; set; }

		public UsuarioPropietarioDTO usuarioPropietario { get; set; }
	}

	public class EventoInsertDTO
	{
		public string? Nombre { get; set; }

		public string? Descripcion { get; set; }

		public DateTime? FechaEvento { get; set; }

		public string? HoraInicio { get; set; }

		public string? HoraFin { get; set; }

		public string? Lugar { get; set; }

		public DateTime? FechaCreacion { get; set; }

		public string? MomentosImportantes { get; set; }

		public int? CantidadInvitados { get; set; }

		public int? IdUsuario { get; set; }
	}

	public class EventoUpdateDTO
	{
		public int IdEvento { get; set; }
		public string? Nombre { get; set; }

		public string? Descripcion { get; set; }

		public DateTime? FechaEvento { get; set; }

		public string? HoraInicio { get; set; }

		public string? HoraFin { get; set; }

		public string? Lugar { get; set; }

		public string? Estado { get; set; }

		public DateTime? FechaCreacion { get; set; }

		public string? MomentosImportantes { get; set; }

		public int? CantidadInvitados { get; set; }

		public int? IdUsuario { get; set; }

	}

	public class EventoPrincipalDTO
	{
		public int IdEvento { get; set; }

		public string? Nombre { get; set; }

		public DateTime? FechaEvento { get; set; }

		public string? Lugar { get; set; }

		public UsuarioPropietarioDTO usuarioPropietario { get; set; }
	}
}
