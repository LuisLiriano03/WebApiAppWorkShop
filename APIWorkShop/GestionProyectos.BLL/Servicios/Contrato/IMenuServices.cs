using GestionProyectos.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionProyectos.BLL.Servicios.Contrato
{
    public interface IMenuServices
    {
        Task<List<MenuDTO>> Lista(int idUsuario);
    }

}
