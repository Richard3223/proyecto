using Microsoft.EntityFrameworkCore;
using proyecto.Models;  

namespace Proyecto.Data 
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        { }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Tecnico> Tecnicos { get; set; }
        public DbSet<Equipo> Equipos { get; set; }
    }
}
