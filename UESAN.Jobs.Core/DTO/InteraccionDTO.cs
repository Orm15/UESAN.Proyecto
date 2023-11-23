using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UESAN.Proyecto.Core.DTO
{
	public class InteraccionDTO
	{
		public int IdInteraccion { get; set; }

		public int? IdUsuario { get; set; }

		public int? IdEvento { get; set; }

		public string? Tipo { get; set; }

		public string? Descripcion { get; set; }

	}

	public class InteraccionInsertDTO
	{
		public int? IdUsuario { get; set; }

		public int? IdEvento { get; set; }

		public string? Tipo { get; set; }

		public string? Descripcion { get; set; }

	}
}
