using Ibiza.Dominio.Repositorio;
using Ibiza.Infraestructura;
using Ibiza.Infraestructura.Repositorio;
using Ibiza.Servicio.Interfaz.Producto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MapperProfiles;

namespace Ibiza.Servicio.Producto
{
    public class ProductoServicio : IProductoServicio
    {
        private readonly IRepositorio<Dominio.Entidades.Producto> _repositorio;
        //private readonly Repositorio<Dominio.Entidades.Producto> producto_repositorio;
        IMapper _mapper;
        DataContext _dataContext;

        public ProductoServicio(IRepositorio<Dominio.Entidades.Producto> repositorio, DataContext dataContext)
        {
            _repositorio = repositorio;
           
            //var config = new MapperConfiguration(c => c.AddProfile<MapperProfiles.MapperProfiles>());
            //_mapper = config.CreateMapper();

            _dataContext = dataContext;
        }

        //public ProductoServicio(Repositorio<Dominio.Entidades.Producto> repositorio, DataContext dataContext)
        //{
        //    repositorio = producto_repositorio;
        //    _dataContext = dataContext;

        //    Console.WriteLine("Constructor vacio");
        //}

        public async Task Add(ProductoDto dto)
        {
            var producto = new Dominio.Entidades.Producto
            {
                Nombre = dto.Nombre,
                Descripcion = dto.Descripcion,
                Cantidad = dto.Cantidad,
                Precio = dto.Precio,

                EstaBorrado = false
            };

            await _repositorio.Create(producto);
        }

        public async Task UpDate(ProductoDto dto)
        {
            // Tambien es posoble hacerlo con un using

            var producto = _dataContext.Productos.FirstOrDefault(x => x.Id == dto.Id);

            producto.Nombre = dto.Nombre;
            producto.Descripcion = dto.Descripcion;
            producto.Cantidad = dto.Cantidad;
            producto.Precio = dto.Precio;

            await _repositorio.Update(producto);

        }

        public async Task Delete(ProductoDto dto)
        {
            var producto = _dataContext.Productos.FirstOrDefault(x => x.Id == dto.Id);

            await _repositorio.Delete(producto);
        }

        public async Task<IEnumerable<ProductoDto>> GetAll()
        {
            var producto = await _repositorio.GetAll();

            return producto.Select(x => new ProductoDto
            {
                Id = x.Id,
                EstaBorrado = x.EstaBorrado,

                Nombre = x.Nombre,
                Descripcion = x.Descripcion,
                Cantidad = x.Cantidad,
                Precio = x.Precio

            }).ToList();
        }

        public async Task<ProductoDto> GetById(long id)
        {
            var producto = await _repositorio.GetById(id);

            if (producto == null)
            {
                return null;
            }
            else
            {
                return new ProductoDto
                {
                    Id = producto.Id,
                    EstaBorrado = producto.EstaBorrado,

                    Nombre = producto.Nombre,
                    Descripcion = producto.Descripcion,
                    Cantidad = producto.Cantidad,
                    Precio = producto.Precio
                };
            }
        }
    }
}
