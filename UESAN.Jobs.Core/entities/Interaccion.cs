using System;
using System.Collections.Generic;

namespace UESAN.Proyecto.Core.entities;

public partial class Interaccion
{
	public int IdInteraccion { get; set; }

	public int? IdUsuario { get; set; }

	public int? IdEvento { get; set; }

	public string? Tipo { get; set; }

	public string? Descripcion { get; set; }

	public virtual Eventos? IdEventoNavigation { get; set; }

	public virtual Usuarios? IdUsuarioNavigation { get; set; }
}
