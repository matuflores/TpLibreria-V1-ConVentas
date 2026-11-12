namespace TpLibreria.Servicios.DTOs.Libro
{
    public class LibroDeleteDto
    {
        public int LibroId { get; set; }
        public byte[] RowVersion { get; set; } = null!;
    }
}
