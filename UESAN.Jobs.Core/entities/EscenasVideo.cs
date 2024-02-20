using System;
using System.Collections.Generic;

namespace UESAN.Proyecto.Core.entities;

public partial class EscenasVideo
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

    public string? Estado { get; set; }

    public virtual ServicioEdicionVideo? IdServicioEdicionVideoNavigation { get; set; }

    public virtual Videos? IdVideoNavigation { get; set; }
}
