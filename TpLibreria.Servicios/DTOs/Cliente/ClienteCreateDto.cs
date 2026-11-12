namespace TpLibreria.Servicios.DTOs.Cliente
{
    public class ClienteCreateDto
    {
        public string Nombre { get; set; } = null!;
        public string Apellido { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? Telefono { get; set; }
    }
}
