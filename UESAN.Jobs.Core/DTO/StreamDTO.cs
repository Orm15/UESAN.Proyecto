using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UESAN.Proyecto.Core.DTO
{
    public class StreamDTO
    {
        public int IdStream { get; set; }

        public int? IdServicios { get; set; }

        public string? Plataforma { get; set; }

        public string? Cuenta { get; set; }

        public string? ContactoCuenta { get; set; }

        public int? NumCam { get; set; }

        public string? Angulo { get; set; }
    }

    public class StreamInsertDTO
    {

        public int? IdServicios { get; set; }

        public string? Plataforma { get; set; }

        public string? Cuenta { get; set; }

        public string? ContactoCuenta { get; set; }

        public int? NumCam { get; set; }

        public string? Angulo { get; set; }
    }

    public class StreamUpdateDTO
    {
        public int IdStream { get; set; }

        public int? IdServicios { get; set; }

        public string? Plataforma { get; set; }

        public string? Cuenta { get; set; }

        public string? ContactoCuenta { get; set; }

        public int? NumCam { get; set; }

        public string? Angulo { get; set; }
    }
}
