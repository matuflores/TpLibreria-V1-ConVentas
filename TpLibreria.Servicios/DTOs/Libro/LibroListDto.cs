namespace TpLibreria.Servicios.DTOs.Libro
{
    public class LibroListDto
    {
        public int LibroId { get; set; }
        public string Tipo { get; set; } = null!;
        // ISBN (libro físico) o identificador (libro digital)
        public string Codigo { get; set; } = null!;
        public string Titulo { get; set; } = null!;
        public string Editorial { get; set; } = null!;
        public string Autores { get; set; } = null!;
        public decimal Precio { get; set; }
        // Los libros digitales no tienen stock
        public int? Stock { get; set; }
        public bool Activo { get; set; }
    }
}
