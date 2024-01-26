using GestionProyectos.BLL.Servicios;
using GestionProyectos.BLL.Servicios.Contrato;
using GestionProyectos.DAL.DBContext;
using GestionProyectos.DTO;
using GestionProyectos.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoGestionAPI.Utilidad;

namespace ProyectoGestionAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProyectoController : ControllerBase
    {
        private readonly IProyectoServices _proyectoServices;

        public ProyectoController(IProyectoServices proyectoServices)
        {
            _proyectoServices = proyectoServices;
        }

        [HttpGet]
        [Route("Lista")]
        public async Task<IActionResult> Lista()
        {
            var respuesta = new Response<List<ProyectoDTO>>();

            try
            {
                respuesta.status = true;
                respuesta.value = await _proyectoServices.Lista();
            }
            catch (Exception ex)
            {
                respuesta.status = false;
                respuesta.mensage = ex.Message;
            }

            return Ok(respuesta);

        }

        [HttpGet]
        [Route("PorUsuario/{idUsuario}")]
        public async Task<IActionResult> ObtenerProyectosPorUsuario(int idUsuario)
        {
            var respuesta = new Response<List<ProyectoDTO>>();

            try
            {
                respuesta.status = true;
                respuesta.value = await _proyectoServices.ObtenerProyectosPorUsuario(idUsuario);
            }
            catch (Exception ex)
            {
                respuesta.status = false;
                respuesta.mensage = ex.Message;
            }

            return Ok(respuesta);
        }

        [HttpPost]
        [Route("Guardar")]
        public async Task<IActionResult> Guardar([FromBody] ProyectoDTO proyecto)
        {
            var respuesta = new Response<ProyectoDTO>();

            try
            {
                respuesta.status = true;
                respuesta.value = await _proyectoServices.Crear(proyecto);
            }
            catch (Exception ex)
            {
                respuesta.status = false;
                respuesta.mensage = ex.Message;
            }

            return Ok(respuesta);

        }

        [HttpPut]
        [Route("Editar")]
        public async Task<IActionResult> Editar([FromBody] ProyectoDTO proyecto)
        {
            var respuesta = new Response<bool>();

            try
            {
                respuesta.status = true;
                respuesta.value = await _proyectoServices.Editar(proyecto);
            }
            catch (Exception ex)
            {
                respuesta.status = false;
                respuesta.mensage = ex.Message;
            }

            return Ok(respuesta);

        }

        [HttpDelete]
        [Route("Eliminar/{id:int}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            var respuesta = new Response<bool>();

            try
            {
                respuesta.status = true;
                respuesta.value = await _proyectoServices.Eliminar(id);
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
