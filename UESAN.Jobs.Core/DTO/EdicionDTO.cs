using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UESAN.Proyecto.Core.DTO
{
	public class EdicionDTO
	{
		public int IdEdicion { get; set; }

		public int? IdVideo { get; set; }

		public string? Musica { get; set; }

		public string? Nombre { get; set; }

		public string? Descripción { get; set; }

	}

	public class EdicionInsertDTO
	{
		public int? IdVideo { get; set; }

		public string? Musica { get; set; }

		public string? Nombre { get; set; }

		public string? Descripción { get; set; }

	}

	public class EdicionUpdateDTO
	{
		public int IdEdicion { get; set; }

		public int? IdVideo { get; set; }

		public string? Musica { get; set; }

		public string? Nombre { get; set; }

		public string? Descripción { get; set; }
	}
}
