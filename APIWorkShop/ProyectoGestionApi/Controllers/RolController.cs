using GestionProyectos.BLL.Servicios.Contrato;
using GestionProyectos.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyectoGestionAPI.Utilidad;

namespace ProyectoGestionAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolController : ControllerBase
    {
        private readonly IRolService _rolService;

        public RolController(IRolService rolService)
        {
            _rolService = rolService;
        }

        [HttpGet]
        [Route("Lista")]
        public async Task<IActionResult> Lista()
        {
            var respuesta = new Response<List<RolDTO>>();

            try
            {
                respuesta.status = true;
                respuesta.value = await _rolService.Lista();
            }
            catch(Exception ex)
            {
                respuesta.status=false;
                respuesta.mensage = ex.Message;
            }

            return Ok(respuesta);

        }

    }

}
