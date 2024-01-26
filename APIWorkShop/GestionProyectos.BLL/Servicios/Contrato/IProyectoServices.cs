using GestionProyectos.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionProyectos.BLL.Servicios.Contrato
{
    public interface IProyectoServices
    {
        Task<List<ProyectoDTO>> Lista();
        Task<List<ProyectoDTO>> ObtenerProyectosPorUsuario(int idUsuario);
        Task<ProyectoDTO> Crear(ProyectoDTO modelo);
        Task<bool> Editar(ProyectoDTO modelo);
        Task<bool> Eliminar(int id);

    }

}
