using System;
using System.Collections.Generic;

namespace UESAN.Proyecto.Core.entities;

public partial class CircuitoCerrado
{
	public int IdCircuitoCerrado { get; set; }

	public int? IdServicio { get; set; }

	public string? Guardar { get; set; }

	public string? Link { get; set; }

	public string? NumeroCamaras { get; set; }

	public string? NumeroAngulos { get; set; }

	public string? Angulos { get; set; }

	public string? Estado { get; set; }

	public virtual Servicios? IdServicioNavigation { get; set; }
}
