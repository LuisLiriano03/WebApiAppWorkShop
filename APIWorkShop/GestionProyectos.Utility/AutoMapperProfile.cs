using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestionProyectos.DTO;
using GestionProyectos.Model;

namespace GestionProyectos.Utility
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Rol,RolDTO>().ReverseMap();

            CreateMap<Menu,MenuDTO>().ReverseMap();

            #region Usuario
            CreateMap<Usuario, UsuarioDTO>()
                .ForMember(destino =>
                    destino.RolDescripcion,
                    options => options.MapFrom(origen => origen.IdRolNavigation.Nombre)
                )
                .ForMember(destino =>
                    destino.EsActivo,
                    options => options.MapFrom(origen => origen.EsActivo == true ? 1 : 0)
                );

            CreateMap<Usuario, SesionDTO>()
                .ForMember(destino =>
                    destino.RolDescripcion,
                    options => options.MapFrom(origen => origen.IdRolNavigation.Nombre)
                );

            CreateMap<UsuarioDTO, Usuario>()
                .ForMember(destino =>
                    destino.IdRolNavigation,
                    options => options.Ignore()
                )
                .ForMember(destino =>
                    destino.EsActivo,
                    options => options.MapFrom(origen => origen.EsActivo == 1 ? true : false)
                );
            #endregion Usuario

            CreateMap<Proyecto, ProyectoDTO>()
                .ForMember(destino =>
                    destino.DescripcionUsuario,
                    opt => opt.MapFrom(origen => origen.IdUsuarioNavigation.NombreCompleto)
                );

            CreateMap<ProyectoDTO, Proyecto>()
                .ForMember(destino =>
                    destino.IdUsuarioNavigation,
                    opt => opt.Ignore()
                );


        }


    }
}
