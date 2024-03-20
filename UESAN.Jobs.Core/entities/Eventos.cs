using System;
using System.Collections.Generic;

namespace UESAN.Proyecto.Core.entities;

public partial class Eventos
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

	public virtual Usuarios? IdUsuarioNavigation { get; set; }

	public virtual ICollection<ServicioEdicionVideo> ServicioEdicionVideo { get; set; } = new List<ServicioEdicionVideo>();

	public virtual ICollection<Servicios> Servicios { get; set; } = new List<Servicios>();
}
