namespace Ibiza.Servicio.Interfaz.Producto
{
    public class ProductoDto
    {
        public long Id { get; set; }

        public bool EstaBorrado { get; set; }

        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        public int Cantidad { get; set; }

        public decimal Precio { get; set; }
    }
}
