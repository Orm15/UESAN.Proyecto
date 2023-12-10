using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UESAN.Proyecto.Core.DTO
{
    public class VideosDTO
    {
        public int IdVideo { get; set; }

        public DateTime? FechaSubida { get; set; }

        public string? Nombre { get; set; }

        public string? Link { get; set; }

        public string? NombreObjetivo { get; set; }

        public string? LugarFilmacion { get; set; }

        public int? Edicion { get; set; }

        public int? IdServicio { get; set; }
    }
}
