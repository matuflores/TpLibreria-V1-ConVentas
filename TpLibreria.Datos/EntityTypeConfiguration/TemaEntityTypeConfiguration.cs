using TpLibreria.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TpLibreria.Datos.EntityTypeConfiguration
{
    public class TemaEntityTypeConfiguration : IEntityTypeConfiguration<Tema>
    {
        public void Configure(EntityTypeBuilder<Tema> builder)
        {
            builder.ToTable("Temas");
            builder.HasKey(x => x.TemaId);
            builder.Property(x => x.Nombre).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Descripcion).HasMaxLength(150);
            builder.Property(x => x.RowVersion).IsRowVersion();
            builder.HasIndex(x => x.Nombre, "IX_Temas_Nombre").IsUnique();
        }
    }
}
