using GestionProyectos.BLL.Servicios;
using GestionProyectos.BLL.Servicios.Contrato;
using GestionProyectos.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyectoGestionAPI.Utilidad;

namespace ProyectoGestionAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        private readonly IMenuServices _menuServices;

        public MenuController(IMenuServices menuServices)
        {
            _menuServices = menuServices;
        }

        [HttpGet]
        [Route("Lista")]
        public async Task<IActionResult> Lista(int idUsuario)
        {
            var respuesta = new Response<List<MenuDTO>>();

            try
            {
                respuesta.status = true;
                respuesta.value = await _menuServices.Lista(idUsuario);
            }
            catch (Exception ex)
            {
                respuesta.status = false;
                respuesta.mensage = ex.Message;
            }

            return Ok(respuesta);

        }

    }

}
