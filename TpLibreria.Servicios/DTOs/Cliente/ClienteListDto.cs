using System.ComponentModel;

namespace TpLibreria.Servicios.DTOs.Cliente
{
    public class ClienteListDto
    {
        public int ClienteId { get; set; }
        public string Nombre { get; set; } = null!;
        public string Apellido { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? Telefono { get; set; }
        [Browsable(false)]
        public string NombreCompleto => $"{Apellido}, {Nombre}";
    }
}
