using TpLibreria.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TpLibreria.Datos.EntityTypeConfiguration
{
    public class LibroEntityTypeConfiguration : IEntityTypeConfiguration<Libro>
    {
        public void Configure(EntityTypeBuilder<Libro> builder)
        {
            
            builder.UseTptMappingStrategy();
            builder.ToTable("Libros");
            builder.HasKey(l => l.LibroId);
            builder.Property(l => l.Titulo).IsRequired().HasMaxLength(100);
            builder.Property(l => l.Descripcion).HasMaxLength(250);
            builder.Property(l => l.AnioPublicacion).IsRequired();
            builder.Property(l => l.Precio).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(l => l.Activo).IsRequired();
            builder.Property(l => l.RowVersion).IsRowVersion();
            builder.Property(l => l.EditorialId).IsRequired();
            builder.Ignore(l => l.Tipo);
            builder.Ignore(l => l.EsVendible);

            
            builder.HasOne(l => l.Editorial)
                .WithMany(e => e.Libros)
                .HasForeignKey(l => l.EditorialId)
                .OnDelete(DeleteBehavior.Restrict);//no puedo borrar una editorial que tenga libros asociados

            
            builder.HasMany(l => l.Autores)
                .WithMany(a => a.Libros)
                .UsingEntity<Dictionary<string, object>>(
                    "LibroAutores",
                    j => j.HasOne<Autor>().WithMany().HasForeignKey("AutorId").OnDelete(DeleteBehavior.Restrict),
                    j => j.HasOne<Libro>().WithMany().HasForeignKey("LibroId").OnDelete(DeleteBehavior.Cascade));

            
            builder.HasMany(l => l.Temas)
                .WithMany(t => t.Libros)
                .UsingEntity<Dictionary<string, object>>(
                    "LibroTemas",
                    j => j.HasOne<Tema>().WithMany().HasForeignKey("TemaId").OnDelete(DeleteBehavior.Restrict),
                    j => j.HasOne<Libro>().WithMany().HasForeignKey("LibroId").OnDelete(DeleteBehavior.Cascade));
        }
    }
}
