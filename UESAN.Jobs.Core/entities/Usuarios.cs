using System;
using System.Collections.Generic;

namespace UESAN.Proyecto.Core.entities;

public partial class Usuarios
{
	public int IdUsuario { get; set; }

	public string? Correo { get; set; }

	public string? Nombre { get; set; }

	public string? Area { get; set; }

	public string? Tipo { get; set; }

	public string? Estado { get; set; }

	public virtual ICollection<Interaccion> Interaccion { get; set; } = new List<Interaccion>();
}
