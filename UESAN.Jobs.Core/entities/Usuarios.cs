using System;
using System.Collections.Generic;

namespace UESAN.Proyecto.Core.entities;

public partial class Usuarios
{
    public int IdUsuario { get; set; }

    public string? Correo { get; set; }

    public string? Nombre { get; set; }

    public string? Area { get; set; }

    public string? Tipo { get; set; }

    public string? Estado { get; set; }

    public string? Contra { get; set; }

    public string? Salt { get; set; }

    public virtual ICollection<Eventos> Eventos { get; set; } = new List<Eventos>();

    public virtual ICollection<ServicioEdicionVideo> ServicioEdicionVideo { get; set; } = new List<ServicioEdicionVideo>();
}
