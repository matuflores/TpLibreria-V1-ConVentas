namespace TpLibreria.Servicios.DTOs.Cliente
{
    public class ClienteComboDto
    {
        public int ClienteId { get; set; }
        public string NombreCompleto { get; set; } = null!;
        public string? Email { get; set; }
        public string? Telefono { get; set; }
    }
}
