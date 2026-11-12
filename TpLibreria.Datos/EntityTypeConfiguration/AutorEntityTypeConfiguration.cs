using TpLibreria.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TpLibreria.Datos.EntityTypeConfiguration
{
    public class AutorEntityTypeConfiguration : IEntityTypeConfiguration<Autor>
    {
        public void Configure(EntityTypeBuilder<Autor> builder)
        {
            builder.ToTable("Autores");
            builder.HasKey(x => x.AutorId);
            builder.Property(x => x.Nombre).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Apellido).IsRequired().HasMaxLength(50);
            builder.Property(x => x.FechaNacimiento).IsRequired().HasColumnType("date");
            builder.Property(x => x.Nacionalidad).IsRequired().HasMaxLength(50);
            builder.Property(x => x.RowVersion).IsRowVersion();
            builder.HasIndex(x => new { x.Nombre, x.Apellido, x.FechaNacimiento }, "IX_Autores_Nombre_Apellido_FechaNacimiento").IsUnique();
            builder.Ignore(x => x.NombreCompleto);
        }
    }
}
