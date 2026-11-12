namespace TpLibreria.Servicios.DTOs.Tema
{
    public class TemaListDto
    {
        public int TemaId { get; set; }
        public string Nombre { get; set; } = null!;
        public string? Descripcion { get; set; }
    }
}
