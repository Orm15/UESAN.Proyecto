using System;
using System.Collections.Generic;

namespace UESAN.Proyecto.Core.entities;

public partial class Stream
{
    public int IdStream { get; set; }

    public int? IdServicios { get; set; }

    public string? Plataforma { get; set; }

    public string? Cuenta { get; set; }

    public string? ContactoCuenta { get; set; }

    public int? NumCam { get; set; }

    public string? Angulo { get; set; }

    public string? Estado { get; set; }

    public virtual Servicios? IdServiciosNavigation { get; set; }
}
