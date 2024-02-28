using System;
using System.Collections.Generic;

namespace UESAN.Proyecto.Core.entities;

public partial class ServicioEdicionVideo
{
	public int IdServicioEdicionVideo { get; set; }

	public int? IdEvento { get; set; }

	public int? IdUsuario { get; set; }

	public string? NombreProyecto { get; set; }

	public string? Objetivo { get; set; }

	public string? Musica { get; set; }

	public string? Logos { get; set; }

	public string? FormatoVideo { get; set; }

	public string? Destino { get; set; }

	public string? DuracionVideo { get; set; }

	public string? NombreEntrevistado { get; set; }

	public string? CarreraCargoEmpresa { get; set; }

	public string? Estado { get; set; }

	public virtual ICollection<EscenasVideo> EscenasVideo { get; set; } = new List<EscenasVideo>();

	public virtual Eventos? IdEventoNavigation { get; set; }

	public virtual Usuarios? IdUsuarioNavigation { get; set; }
}
