using AutoMapper;
using GestionProyectos.BLL.Servicios.Contrato;
using GestionProyectos.DAL.Repositorios.Contrato;
using GestionProyectos.DTO;
using GestionProyectos.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionProyectos.BLL.Servicios
{
    public class ProyectoServices : IProyectoServices
    {
        private readonly IGenericRepository<Proyecto> _proyectoRepositorio;
        private readonly IMapper _mapper;

        public ProyectoServices(IGenericRepository<Proyecto> proyectoRepositorio, IMapper mapper)
        {
            _proyectoRepositorio = proyectoRepositorio;
            _mapper = mapper;
        }

        public async Task<List<ProyectoDTO>> Lista()
        {
            try
            {
                var queryProyecto = await _proyectoRepositorio.Consultar();

                var listaProyecto = queryProyecto.Include(usuario => usuario.IdUsuarioNavigation).ToList();

                return _mapper.Map<List<ProyectoDTO>>(listaProyecto.ToList());

            }
            catch
            {
                throw;
            }

        }

        public async Task<List<ProyectoDTO>> ObtenerProyectosPorUsuario(int idUsuario)
        {
            try
            {
                var proyectosAsignados = await _proyectoRepositorio
                    .Consultar(proyecto => proyecto.IdUsuario == idUsuario);

                var proyectosConInclude = proyectosAsignados
                    .Include(usuario => usuario.IdUsuarioNavigation);

                var listaProyectos = await proyectosConInclude.ToListAsync();

                return _mapper.Map<List<ProyectoDTO>>(listaProyectos);
            }
            catch
            {
                throw;
            }
        }

        public async Task<ProyectoDTO> Crear(ProyectoDTO modelo)
        {
            try
            {
                var proyectoCreado = await _proyectoRepositorio.Crear(_mapper.Map<Proyecto>(modelo));

                if (proyectoCreado.IdProyecto == 0)
                    throw new TaskCanceledException("No se pudo crear");

                var query = await _proyectoRepositorio.Consultar(u => u.IdProyecto == proyectoCreado.IdProyecto);

                proyectoCreado = query.Include(rol => rol.IdUsuarioNavigation).First();

                return _mapper.Map<ProyectoDTO>(proyectoCreado);

            }
            catch
            {
                throw;
            }

        }

        public async Task<bool> Editar(ProyectoDTO modelo)
        {
            try 
            {
                var proyectoModel = _mapper.Map<Proyecto>(modelo);
                var proyectoEncontrado = await _proyectoRepositorio.Obtener(u => u.IdProyecto == proyectoModel.IdProyecto);

                if (proyectoEncontrado == null)
                    throw new TaskCanceledException("El proyecto no existe");

                proyectoEncontrado.Descripcion = proyectoModel.Descripcion;
                proyectoEncontrado.IdUsuario = proyectoModel.IdUsuario;

                bool respuesta = await _proyectoRepositorio.Editar(proyectoEncontrado);

                if (!respuesta)
                    throw new TaskCanceledException("No se pudo editar");

                return respuesta;

            }
            catch
            {
                throw;
            }

        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                var proyectoEncontrado = await _proyectoRepositorio.Obtener(u => u.IdProyecto == id);

                if (proyectoEncontrado == null)
                    throw new TaskCanceledException("El proyecto no existe");

                bool respuesta = await _proyectoRepositorio.Eliminar(proyectoEncontrado);

                if (!respuesta)
                    throw new TaskCanceledException("No se pudo eliminar");

                return respuesta;
            }
            catch
            {
                throw;
            }
        }
        
    }

}
