using TpLibreria.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TpLibreria.Datos.EntityTypeConfiguration
{
    public class ClienteEntityTypeConfiguration : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("Clientes");
            builder.HasKey(x => x.ClienteId);
            builder.Property(x => x.Nombre).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Apellido).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Email).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Telefono).HasMaxLength(20);
            builder.Property(x => x.RowVersion).IsRowVersion();
            builder.HasIndex(x => x.Email, "IX_Clientes_Email").IsUnique();
            builder.Ignore(x => x.NombreCompleto);
        }
    }
}
