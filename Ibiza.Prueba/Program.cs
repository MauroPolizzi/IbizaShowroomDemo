using Ibiza.Dominio.Entidades;
using Ibiza.Dominio.Repositorio;
using Ibiza.Infraestructura;
using Ibiza.Infraestructura.Repositorio;
using Ibiza.Servicio.Producto;
using System;

namespace Ibiza.Prueba
{
    class Program
    {
        static void Main(string[] args)
        {
            prueba();
        }

        public async static void prueba()
        {
            ProductoServicio _productoServicio = new ProductoServicio(new Repositorio<Producto>(), new DataContext());

            var lista = await _productoServicio.GetAll();

            Console.WriteLine(lista);
            Console.ReadKey();

        }
    }
}
