using System;
using System.Collections.Generic;

namespace GestionProyectos.Model;

public partial class Proyecto
{
    public int IdProyecto { get; set; }

    public string? Descripcion { get; set; }

    public int? IdUsuario { get; set; }

    public DateTime? FechaRegistro { get; set; }

    public virtual Usuario? IdUsuarioNavigation { get; set; }
}
