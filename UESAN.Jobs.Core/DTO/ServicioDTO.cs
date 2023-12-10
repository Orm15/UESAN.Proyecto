using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UESAN.Proyecto.Core.DTO
{
	public class ServicioDTO
	{
		public int IdServicios { get; set; }

		public string? Nombre { get; set; }

		public string? Tipo { get; set; }

		public string? Estado { get; set; }

		public EventoPrincipalDTO eventoPrincipal { get; set; }
	}

	public class ServicioUpdateDTO
	{
		public int IdServicios { get; set; }

		public int? IdEvento { get; set; }

		public string? Nombre { get; set; }

		public string? Tipo { get; set; }

		public string? Estado { get; set; }
	}

	public class ServicioInsertDTO
	{
		public int? IdEvento { get; set; }

		public string? Nombre { get; set; }

		public string? Tipo { get; set; }

	}
}
