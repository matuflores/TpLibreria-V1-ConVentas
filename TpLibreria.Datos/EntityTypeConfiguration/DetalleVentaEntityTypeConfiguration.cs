using TpLibreria.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TpLibreria.Datos.EntityTypeConfiguration
{
    public class DetalleVentaEntityTypeConfiguration : IEntityTypeConfiguration<DetalleVenta>
    {
        public void Configure(EntityTypeBuilder<DetalleVenta> builder)
        {
            builder.ToTable("DetallesVenta");
            builder.HasKey(d => d.DetalleVentaId);
            builder.Property(d => d.Cantidad).IsRequired();
            builder.Property(d => d.PrecioUnitario).IsRequired().HasColumnType("decimal(18,2)");
            builder.Ignore(d => d.Subtotal);

            builder.HasOne(d => d.Libro)
                .WithMany(l => l.Detalles)
                .HasForeignKey(d => d.LibroId)
                .OnDelete(DeleteBehavior.Restrict);//no se puede borrar un libro que tenga detalles de venta asociados
        }
    }
}
