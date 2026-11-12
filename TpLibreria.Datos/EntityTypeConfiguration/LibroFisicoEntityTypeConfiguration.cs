using TpLibreria.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TpLibreria.Datos.EntityTypeConfiguration
{
    public class LibroFisicoEntityTypeConfiguration : IEntityTypeConfiguration<LibroFisico>
    {
        public void Configure(EntityTypeBuilder<LibroFisico> builder)
        {
            builder.ToTable("LibrosFisicos");
            builder.Property(l => l.Isbn).IsRequired().HasMaxLength(13);
            builder.HasIndex(l => l.Isbn, "IX_LibrosFisicos_Isbn").IsUnique();
            builder.Property(l => l.Stock).IsRequired();
        }
    }
}
