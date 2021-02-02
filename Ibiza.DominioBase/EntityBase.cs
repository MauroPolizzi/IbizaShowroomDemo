using System.ComponentModel.DataAnnotations;

namespace Ibiza.DominioBase
{
    public class EntityBase
    {
        [Key]
        public long Id { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }

        [Required]
        public bool EstaBorrado { get; set; }
    }
}
