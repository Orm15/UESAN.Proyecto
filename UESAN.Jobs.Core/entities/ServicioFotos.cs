using System;
using System.Collections.Generic;

namespace UESAN.Proyecto.Core.entities;

public partial class ServicioFotos
{
	public int IdServicioFotos { get; set; }

	public int? IdServicio { get; set; }

	public string? CantidadFotos { get; set; }

	public string? Tipo { get; set; }

	public string? PesonaObjetivo { get; set; }

	public string? Canales { get; set; }

	public string? Link { get; set; }

	public string? Estado { get; set; }

	public virtual Servicios? IdServicioNavigation { get; set; }
}
