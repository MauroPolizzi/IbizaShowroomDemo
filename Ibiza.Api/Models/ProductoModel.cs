namespace Ibiza.Api.Models
{
    public class ProductoModel
    {
        public long Id { get; set; }

        public bool EstaBorrado { get; set; }

        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        public int Cantidad { get; set; }

        public decimal Precio { get; set; }
    }
}
