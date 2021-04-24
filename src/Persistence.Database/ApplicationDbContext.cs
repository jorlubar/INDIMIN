using INDIMIN.Model;
using Microsoft.EntityFrameworkCore;
using Persistence.Database.Config;

namespace Persistence.Database
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { 
            
        }
        public DbSet<Tarea> Tareas { get; set; }
        public DbSet<Ciudadano> Ciudadanos { get; set; }
        public DbSet<Dia> Dias { get; set; }
        public DbSet<EjecutarTarea> EjecutarTareas { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            new CiudadanoConfig(builder.Entity<Ciudadano>());
            new TareaConfig(builder.Entity<Tarea>());
            new DiaConfig(builder.Entity<Dia>());
        }
    }
}
