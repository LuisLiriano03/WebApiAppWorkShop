using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionProyectos.DTO
{
    public class ProyectoDTO
    {
        public int IdProyecto { get; set; }
        public string? Descripcion { get; set; }
        public int? IdUsuario { get; set; }
        public string? DescripcionUsuario { get; set; }
    }

}
