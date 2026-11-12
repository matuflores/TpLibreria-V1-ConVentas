namespace TpLibreria.Servicios.DTOs.Editorial
{
    public class EditorialDeleteDto
    {
        public int EditorialId { get; set; }
        public byte[] RowVersion { get; set; } = null!;
    }
}
