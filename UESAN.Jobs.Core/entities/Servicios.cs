using System;
using System.Collections.Generic;

namespace UESAN.Proyecto.Core.entities;

public partial class Servicios
{
	public int IdServicios { get; set; }

	public int? IdEvento { get; set; }

	public string? Nombre { get; set; }

	public string? Tipo { get; set; }

	public string? Estado { get; set; }

	public virtual ICollection<CircuitoCerrado> CircuitoCerrado { get; set; } = new List<CircuitoCerrado>();

	public virtual Eventos? IdEventoNavigation { get; set; }

	public virtual ICollection<ServicioFotos> ServicioFotos { get; set; } = new List<ServicioFotos>();

	public virtual ICollection<Stream> Stream { get; set; } = new List<Stream>();

	public virtual ICollection<Videos> Videos { get; set; } = new List<Videos>();
}
