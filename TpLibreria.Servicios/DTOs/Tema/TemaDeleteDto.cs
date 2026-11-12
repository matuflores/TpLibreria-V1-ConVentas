namespace TpLibreria.Servicios.DTOs.Tema
{
    public class TemaDeleteDto
    {
        public int TemaId { get; set; }
        public byte[] RowVersion { get; set; } = null!;
    }
}
