using System;
using System.Collections.Generic;

namespace UESAN.Proyecto.Core.entities;

public partial class Servicios
{
	public int IdServicios { get; set; }

	public int? IdEvento { get; set; }

	public string? Nombre { get; set; }

	public string? Tipo { get; set; }

	public virtual ICollection<Foto> Foto { get; set; } = new List<Foto>();

	public virtual Eventos? IdEventoNavigation { get; set; }

	public virtual ICollection<Videos> Videos { get; set; } = new List<Videos>();
}
