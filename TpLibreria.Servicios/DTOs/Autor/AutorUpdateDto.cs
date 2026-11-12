namespace TpLibreria.Servicios.DTOs.Autor
{
    public class AutorUpdateDto
    {
        public int AutorId { get; set; }
        public string Nombre { get; set; } = null!;
        public string Apellido { get; set; } = null!;
        public DateTime FechaNacimiento { get; set; }
        public string Nacionalidad { get; set; } = null!;
        public byte[] RowVersion { get; set; } = null!;
    }
}
