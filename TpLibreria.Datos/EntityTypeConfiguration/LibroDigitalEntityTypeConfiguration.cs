using TpLibreria.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TpLibreria.Datos.EntityTypeConfiguration
{
    public class LibroDigitalEntityTypeConfiguration : IEntityTypeConfiguration<LibroDigital>
    {
        public void Configure(EntityTypeBuilder<LibroDigital> builder)
        {
            builder.ToTable("LibrosDigitales");
            builder.Property(l => l.Identificador).IsRequired().HasMaxLength(50);
            builder.HasIndex(l => l.Identificador, "IX_LibrosDigitales_Identificador").IsUnique();
            builder.Property(l => l.Formato).IsRequired().HasMaxLength(20);
            builder.Property(l => l.TamanoArchivo).IsRequired();
            builder.Property(l => l.UrlDescarga).IsRequired().HasMaxLength(250);
        }
    }
}
