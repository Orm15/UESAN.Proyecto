using System;
using System.Collections.Generic;

namespace UESAN.Proyecto.Core.entities;

public partial class Stream
{
	public int IdStream { get; set; }

	public int? IdServicios { get; set; }

	public virtual Servicios? IdServiciosNavigation { get; set; }
}
