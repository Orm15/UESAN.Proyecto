using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UESAN.Proyecto.Core.DTO
{
    public class ServicioFotosDTO
    {
        public int IdServicioFotos { get; set; }

        public int? IdServicio { get; set; }

        public string? CantidadFotos { get; set; }

        public string? TipoFoto { get; set; }

        public string? PesonaObjetivo { get; set; }

        public string? Canales { get; set; }

        public string? Link { get; set; }
    }

    public class ServicioFotosUpdateDTO
    {
		public int IdServicioFotos { get; set; }

		public int? IdServicio { get; set; }

		public string? CantidadFotos { get; set; }

		public string? TipoFoto { get; set; }

		public string? PesonaObjetivo { get; set; }

		public string? Canales { get; set; }

		public string? Link { get; set; }
	}

    public class ServicioFotosInsertDTO
    {
		public int? IdServicio { get; set; }

		public string? CantidadFotos { get; set; }

		public string? TipoFoto { get; set; }

		public string? PesonaObjetivo { get; set; }

		public string? Canales { get; set; }

		public string? Link { get; set; }
	}
}
