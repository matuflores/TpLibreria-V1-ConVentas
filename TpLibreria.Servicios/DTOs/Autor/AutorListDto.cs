using System.ComponentModel;

namespace TpLibreria.Servicios.DTOs.Autor
{
    public class AutorListDto
    {
        public int AutorId { get; set; }
        public string Nombre { get; set; } = null!;
        public string Apellido { get; set; } = null!;
        public DateTime FechaNacimiento { get; set; }
        public string Nacionalidad { get; set; } = null!;
        [Browsable(false)]
        public string NombreCompleto => $"{Apellido}, {Nombre}";
    }
}
