using AutoMapper;
using Ibiza.Dominio.Entidades;
using Ibiza.Servicio.Interfaz.Producto;

namespace MapperProfiles
{
    public class MapperProfiles : Profile
    {
        public MapperProfiles()
        {
            CreateMap<ProductoDto, Producto>().ReverseMap();
        }
    }
}
