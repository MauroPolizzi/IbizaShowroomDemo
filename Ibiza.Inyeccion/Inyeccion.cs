using Ibiza.Dominio.Repositorio;
using Ibiza.Infraestructura;
using Ibiza.Infraestructura.Repositorio;
using Ibiza.Servicio.Interfaz.Producto;
using Ibiza.Servicio.Producto;
using Microsoft.Extensions.DependencyInjection;

namespace Ibiza.Inyeccion
{
    public class Inyeccion
    {
        public static void ConfiguracionServicios(IServiceCollection services)
        {
            services.AddDbContext<DataContext>();
            
            services.AddTransient<IProductoServicio, ProductoServicio>();
            services.AddTransient<IRepositorio<Dominio.Entidades.Producto>, Repositorio<Dominio.Entidades.Producto>>();
        }
    }
}
