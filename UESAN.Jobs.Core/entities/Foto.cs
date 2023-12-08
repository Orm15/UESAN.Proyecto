using System;
using System.Collections.Generic;

namespace UESAN.Proyecto.Core.entities;

public partial class Foto
{
	public int IdFoto { get; set; }

	public string? UbicacionFoto { get; set; }

	public string? Canales { get; set; }

	public string? TipoFoto { get; set; }

	public string? Nombre { get; set; }

	public string? Link { get; set; }

	public DateTime? FechaSubida { get; set; }

	public virtual ICollection<ServicioFotos> ServicioFotos { get; set; } = new List<ServicioFotos>();
}
