using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Ibiza.Dominio.Entidades;
using Ibiza.Infraestructura;
using Ibiza.Api.Models;
using Ibiza.Servicio.Interfaz.Producto;
using AutoMapper;

namespace Ibiza.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly IProductoServicio _productoServicio;
        private readonly IMapper _mapper;
        private readonly DataContext _context;

        public ProductoController(DataContext context, IProductoServicio productoServicio)
        {
            _productoServicio = productoServicio;
            _context = context;
            
            //var conig = new MapperConfiguration(c => c.AddProfile<PerfilCreation>());
            //_mapper = conig.CreateMapper();
        }

        // GET: api/Producto
        [HttpGet]
        [Route("getproductos")]
        public  async Task<IActionResult> GetProductos()
        {

            try
            {
                var producto =  await _productoServicio.GetAll();
                return Ok(producto);

            }
            catch (System.ArgumentException)
            {
                return NotFound();
            }
            catch
            {
                return BadRequest("No se encontro nada");
            }
        }

        // GET: api/Producto/5
        [HttpGet("{id}")]
        [Route("getproducto")]
        public async Task<ActionResult<Producto>> GetProducto(long id)
        {
            try
            {
                var producto = await _productoServicio.GetById(id);

                if (producto == null)
                {
                    return NotFound("Producto Inexistente.");
                }

                return Ok(producto);
            }
            catch (System.ArgumentException)
            {
                return NotFound("No se encontro el producto.");
            }

            //Resolvimos el error de que no traia el id
            //Ahora hay que seguir trabajando en el metodo DELETE del front
        }

        // POST: api/Producto
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        [Route("postproducto")]
        public async Task<IActionResult> PostProducto(ProductoModel dto)
        {
            var producto = new ProductoDto
            {
                Nombre = dto.Nombre,
                Descripcion = dto.Descripcion,
                Cantidad = dto.Cantidad,
                Precio = dto.Precio,

                EstaBorrado = dto.EstaBorrado
            };

            await _productoServicio.Add(producto);
            return Ok(dto);
        }

        // PUT: api/Producto/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        [Route("putproducto")]
        public async Task<IActionResult> PutProducto(ProductoDto dto)
        {
            var producto = new ProductoDto
            {
                Id = dto.Id,
                EstaBorrado = dto.EstaBorrado,
                Nombre = dto.Nombre,
                Descripcion = dto.Descripcion,
                Cantidad = dto.Cantidad,
                Precio = dto.Precio

            };

            await _productoServicio.UpDate(producto);
            return Ok(dto);
        }

        // DELETE: api/Producto/5
        [HttpDelete("{id}")]
        [Route("deleteproducto")]
        public async Task<ActionResult<Producto>> DeleteProducto(ProductoDto dto)
        {
            var producto = new ProductoDto
            {
                Id = dto.Id
            };

            await _productoServicio.Delete(producto);
            return Ok(dto);
        }

        private bool ProductoExists(long id)
        {
            return _context.Productos.Any(e => e.Id == id);
        }
    }
}
