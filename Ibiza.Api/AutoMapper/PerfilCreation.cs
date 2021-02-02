using AutoMapper;
using Ibiza.Api.Models;
using Ibiza.Servicio.Interfaz.Producto;

namespace Ibiza.Api.AutoMapper
{
    public class PerfilCreation : Profile
    {
        public PerfilCreation()
        {
            CreateMap<ProductoModel, ProductoDto>().ReverseMap();
        }
    }
}
