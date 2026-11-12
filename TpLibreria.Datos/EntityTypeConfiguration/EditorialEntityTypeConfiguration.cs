using TpLibreria.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TpLibreria.Datos.EntityTypeConfiguration
{
    public class EditorialEntityTypeConfiguration : IEntityTypeConfiguration<Editorial>
    {
        public void Configure(EntityTypeBuilder<Editorial> builder)
        {
            builder.ToTable("Editoriales");
            builder.HasKey(x => x.EditorialId);
            builder.Property(x => x.Nombre).IsRequired().HasMaxLength(100);
            builder.Property(x => x.PaisOrigen).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Activo).IsRequired();
            builder.Property(x => x.RowVersion).IsRowVersion();
            builder.HasIndex(x => x.Nombre, "IX_Editoriales_Nombre").IsUnique();
        }
    }
}
