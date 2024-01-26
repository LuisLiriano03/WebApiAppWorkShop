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
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuariosServices _usuarioServico;

        public UsuarioController(IUsuariosServices usuarioServico)
        {
            _usuarioServico = usuarioServico;
        }


        [HttpGet]
        [Route("Lista")]
        public async Task<IActionResult> Lista()
        {
            var respuesta = new Response<List<UsuarioDTO>>();

            try
            {
                respuesta.status = true;
                respuesta.value = await _usuarioServico.Lista();
            }
            catch (Exception ex)
            {
                respuesta.status = false;
                respuesta.mensage = ex.Message;
            }

            return Ok(respuesta);

        }

        [HttpPost]
        [Route("IniciarSeccion")]
        public async Task<IActionResult> IniciarSeccion([FromBody] LoginDTO login)
        {
            var respuesta = new Response<SesionDTO>();

            try
            {
                respuesta.status = true;
                respuesta.value = await _usuarioServico.ValidarCredenciales(login.Correo,login.Clave);
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
        public async Task<IActionResult> Guardar([FromBody] UsuarioDTO usuario)
        {
            var respuesta = new Response<UsuarioDTO>();

            try
            {
                respuesta.status = true;
                respuesta.value = await _usuarioServico.Crear(usuario);
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
        public async Task<IActionResult> Editar([FromBody] UsuarioDTO usuario)
        {
            var respuesta = new Response<bool>();

            try
            {
                respuesta.status = true;
                respuesta.value = await _usuarioServico.Editar(usuario);
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
                respuesta.value = await _usuarioServico.Eliminar(id);
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
