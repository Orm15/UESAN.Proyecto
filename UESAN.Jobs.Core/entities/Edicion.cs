using System;
using System.Collections.Generic;

namespace UESAN.Proyecto.Core.entities;

public partial class Edicion
{
	public int IdEdicion { get; set; }

	public int? IdVideo { get; set; }

	public string? Musica { get; set; }

	public string? Nombre { get; set; }

	public string? Descripción { get; set; }

	public string? Estado { get; set; }

	public virtual Videos? IdVideoNavigation { get; set; }
}
