using System;
using System.Collections.Generic;

namespace UESAN.Proyecto.Core.entities;

public partial class ServicioFotos
{
	public int IdServicioFotos { get; set; }

	public int? IdServicio { get; set; }

	public int? IdFotos { get; set; }

	public string? CantidadFotos { get; set; }

	public string? Tipo { get; set; }

	public string? PesonaObjetivo { get; set; }

	public virtual Foto? IdFotosNavigation { get; set; }

	public virtual Servicios? IdServicioNavigation { get; set; }
}
