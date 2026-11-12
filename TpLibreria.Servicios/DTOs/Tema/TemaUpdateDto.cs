namespace TpLibreria.Servicios.DTOs.Tema
{
    public class TemaUpdateDto
    {
        public int TemaId { get; set; }
        public string Nombre { get; set; } = null!;
        public string? Descripcion { get; set; }
        public byte[] RowVersion { get; set; } = null!;
    }
}
