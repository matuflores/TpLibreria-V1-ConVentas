namespace TpLibreria.Servicios.DTOs.Libro
{
    public class LibroComboDto
    {
        public int LibroId { get; set; }
        public string Titulo { get; set; } = null!;
        public string Tipo { get; set; } = null!;
        // Texto que se muestra en el combo
        public string Texto { get; set; } = null!;
        public decimal Precio { get; set; }
        public bool EsFisico { get; set; }
        public int Stock { get; set; }
    }
}
