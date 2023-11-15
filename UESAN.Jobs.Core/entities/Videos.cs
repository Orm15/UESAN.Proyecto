using System;
using System.Collections.Generic;

namespace UESAN.Proyecto.Core.entities;

public partial class Videos
{
	public int IdVideo { get; set; }

	public int? IdServicio { get; set; }

	public DateTime? FechaSubida { get; set; }

	public string? Nombre { get; set; }

	public string? Link { get; set; }

	public string? NombreObjetivo { get; set; }

	public string? LugarFilmacion { get; set; }

	public virtual Servicios? IdServicioNavigation { get; set; }
}
