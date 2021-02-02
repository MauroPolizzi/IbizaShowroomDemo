using Microsoft.EntityFrameworkCore;
using static Ibiza.CadenaConexion.ConexionDb;
using Ibiza.Dominio.Entidades;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;

namespace Ibiza.Infraestructura
{
    public class DataContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ObtenerCadenaConexionWin);

            base.OnConfiguring(optionsBuilder);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entidad in ChangeTracker.Entries()
               .Where(x => x.State == EntityState.Deleted
                           && x.OriginalValues.Properties
                               .Any(p => p.Name.Contains("EstaBorrado"))))
            {
                entidad.State = EntityState.Unchanged;
                entidad.CurrentValues["EstaBorrado"] = true;
            }

            return base.SaveChangesAsync();
        }

        public DbSet<Producto> Productos { get; set; }
    }
}
