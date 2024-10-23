using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PortalProductores.Domain.Entities;

namespace PortalProductores.Infrastructure.Context
{
    public class PersistenceContext(
        DbContextOptions<PersistenceContext> _options,
        IConfiguration _config
    ) : DbContext(_options)
    {
        public async Task CommitAsync()
        {
            await SaveChangesAsync().ConfigureAwait(false);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_config.GetConnectionString("Database"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            if (modelBuilder == null)
            {
                return;
            }

            modelBuilder.Entity<Productor>();
            modelBuilder.Entity<Usuario>();
            modelBuilder.Entity<UsuarioProductor>();
            modelBuilder.Entity<Centro>();
            modelBuilder.Entity<Especie>();
            modelBuilder.Entity<Temporada>();
            modelBuilder.Entity<Variedad>();
            modelBuilder.Entity<Recepcion>();
            modelBuilder.Entity<UnidadMedida>();
            modelBuilder.Entity<Planta>();
            modelBuilder.Entity<Proceso>();

            base.OnModelCreating(modelBuilder);
        }
    }
}
