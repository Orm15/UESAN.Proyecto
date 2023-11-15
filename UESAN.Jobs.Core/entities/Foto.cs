using System;
using System.Collections.Generic;

namespace UESAN.Proyecto.Core.entities;

public partial class Foto
{
	public int IdFoto { get; set; }

	public int? IdServicios { get; set; }

	public int? CantidadFotos { get; set; }

	public string? NombrePersonaObjetivo { get; set; }

	public string? UbicacionFoto { get; set; }

	public string? Canales { get; set; }

	public string? TipoFoto { get; set; }

	public string? Nombre { get; set; }

	public string? Link { get; set; }

	public DateTime? FechaSubida { get; set; }

	public virtual Servicios? IdServiciosNavigation { get; set; }
}
