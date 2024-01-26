using GestionProyectos.DAL.DBContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using GestionProyectos.DAL.Repositorios.Contrato;
using GestionProyectos.DAL.Repositorios;
using GestionProyectos.Utility;
using GestionProyectos.BLL.Servicios.Contrato;
using GestionProyectos.BLL.Servicios;

namespace GestionProyectos.IOC
{
    public static class Dependencia
    {
        public static void InyectarDependencia (this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DbgestionProyectosUsuariosContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("cadenaSQL"));
            });

            services.AddTransient(typeof(IGenericRepository<>),typeof(GenericRepository<>));

            services.AddAutoMapper(typeof(AutoMapperProfile));

            services.AddScoped<IRolService, RolService>();
            services.AddScoped<IUsuariosServices, UsuariosServices>();
            services.AddScoped<IMenuServices, MenuServices>();
            services.AddScoped<IProyectoServices, ProyectoServices>();

        }

    }

}
