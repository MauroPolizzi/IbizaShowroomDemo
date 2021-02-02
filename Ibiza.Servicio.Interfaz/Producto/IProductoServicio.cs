using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ibiza.Servicio.Interfaz.Producto
{
    public interface IProductoServicio
    {
        Task Add(ProductoDto dto); 

        Task UpDate(ProductoDto dto);

        Task Delete(ProductoDto dto);

        Task<IEnumerable<ProductoDto>> GetAll();

        Task<ProductoDto> GetById(long id);
    }
}
