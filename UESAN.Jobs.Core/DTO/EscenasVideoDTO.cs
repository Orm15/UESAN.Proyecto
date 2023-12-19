using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UESAN.Proyecto.Core.DTO
{
	public class EscenasVideoDTO
	{
		public int IdEscena { get; set; }

		public int? IdServicioEdicionVideo { get; set; }

		public int? IdVideo { get; set; }

		public string? NombreVideo { get; set; }

		public string? LinkVideo { get; set; }

		public string? NombreEscena { get; set; }

		public string? DescripcionEscena { get; set; }

		public string? Tiempo { get; set; }

		public string? Cambios { get; set; }

	}

	public class EscenasVideoUpdateDTO
	{
		public int IdEscena { get; set; }

		public int? IdServicioEdicionVideo { get; set; }

		public int? IdVideo { get; set; }

		public string? NombreVideo { get; set; }

		public string? LinkVideo { get; set; }

		public string? NombreEscena { get; set; }

		public string? DescripcionEscena { get; set; }

		public string? Tiempo { get; set; }

		public string? Cambios { get; set; }
	}

	public class EscenasVideoInsertDTO
	{
		public int? IdServicioEdicionVideo { get; set; }

		public int? IdVideo { get; set; }

		public string? NombreVideo { get; set; }

		public string? LinkVideo { get; set; }

		public string? NombreEscena { get; set; }

		public string? DescripcionEscena { get; set; }

		public string? Tiempo { get; set; }

		public string? Cambios { get; set; }
	}
}
