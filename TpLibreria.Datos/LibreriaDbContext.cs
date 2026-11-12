using TpLibreria.Entidades;
using Microsoft.EntityFrameworkCore;

namespace TpLibreria.Datos
{
    public class LibreriaDbContext : DbContext
    {
        public DbSet<Editorial> Editoriales { get; set; }
        public DbSet<Autor> Autores { get; set; }
        public DbSet<Tema> Temas { get; set; }
        public DbSet<Libro> Libros { get; set; }
        public DbSet<LibroFisico> LibrosFisicos { get; set; }
        public DbSet<LibroDigital> LibrosDigitales { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Venta> Ventas { get; set; }
        public DbSet<DetalleVenta> DetallesVenta { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=TpLibreriaFinalDb;Integrated Security=True;TrustServerCertificate=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(LibreriaDbContext).Assembly);
        }
    }
}
