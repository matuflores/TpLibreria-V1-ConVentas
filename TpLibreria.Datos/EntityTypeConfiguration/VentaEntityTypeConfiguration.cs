using TpLibreria.Entidades;
using TpLibreria.Entidades.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TpLibreria.Datos.EntityTypeConfiguration
{
    public class VentaEntityTypeConfiguration : IEntityTypeConfiguration<Venta>
    {
        public void Configure(EntityTypeBuilder<Venta> builder)
        {
            builder.ToTable("Ventas");
            builder.HasKey(v => v.VentaId);
            builder.Property(v => v.Fecha).IsRequired();
            builder.Property(v => v.ImporteTotal).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(v => v.TipoVenta).IsRequired().HasConversion<string>().HasMaxLength(20);
            builder.Property(v => v.Estado).IsRequired().HasConversion<string>().HasMaxLength(20);
            builder.Property(v => v.RowVersion).IsRowVersion();

            
            builder.HasOne(v => v.Cliente)
                .WithMany(c => c.Ventas)
                .HasForeignKey(v => v.ClienteId)
                .OnDelete(DeleteBehavior.Restrict);

           
            builder.HasMany(v => v.Detalles)
                .WithOne(d => d.Venta)
                .HasForeignKey(d => d.VentaId)
                .OnDelete(DeleteBehavior.Cascade);
            builder.Navigation(v => v.Detalles)
                .UsePropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
