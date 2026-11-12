using TpLibreria.Entidades.Enums;

namespace TpLibreria.Servicios.DTOs.Libro
{
    public class LibroUpdateDto
    {
        public int LibroId { get; set; }
        public TipoLibro Tipo { get; set; }
        public string Titulo { get; set; } = null!;
        public string? Descripcion { get; set; }
        public int AnioPublicacion { get; set; }
        public decimal Precio { get; set; }
        public int EditorialId { get; set; }
        public List<int> AutoresIds { get; set; } = new();
        public List<int> TemasIds { get; set; } = new();
        public bool Activo { get; set; }
        public byte[] RowVersion { get; set; } = null!;

        // Solo libros físicos
        public string? Isbn { get; set; }
        public int Stock { get; set; }

        // Solo libros digitales
        public string? Identificador { get; set; }
        public string? Formato { get; set; }
        public long TamanoArchivo { get; set; }
        public string? UrlDescarga { get; set; }
    }
}
