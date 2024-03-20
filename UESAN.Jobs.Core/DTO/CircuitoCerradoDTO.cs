using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UESAN.Proyecto.Core.DTO
{
	public class CircuitoCerradoDTO
	{
		public int IdCircuitoCerrado { get; set; }

		public int? IdServicio { get; set; }

		public string? Guardar { get; set; }

		public string? Link { get; set; }

		public string? NumeroCamaras { get; set; }

		public string? NumeroAngulos { get; set; }

		public string? Angulos { get; set; }
	}

	public class CircuitoCerradoInsertDTO
	{
		public int? IdServicio { get; set; }

		public string? Guardar { get; set; }

		public string? Link { get; set; }

		public string? NumeroCamaras { get; set; }

		public string? NumeroAngulos { get; set; }

		public string? Angulos { get; set; }
	}

	public class CircuitoCerradoUpdateDTO {
		public int IdCircuitoCerrado { get; set; }

		public int? IdServicio { get; set; }

		public string? Guardar { get; set; }

		public string? Link { get; set; }

		public string? NumeroCamaras { get; set; }

		public string? NumeroAngulos { get; set; }

		public string? Angulos { get; set; }
	}



}
