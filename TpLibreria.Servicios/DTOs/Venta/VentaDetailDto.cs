using TpLibreria.Servicios.DTOs.DetalleVenta;

namespace TpLibreria.Servicios.DTOs.Venta
{
    public class VentaDetailDto
    {
        public int VentaId { get; set; }
        public DateTime Fecha { get; set; }
        public string Cliente { get; set; } = null!;
        public string TipoVenta { get; set; } = null!;
        public string Estado { get; set; } = null!;
        public decimal ImporteTotal { get; set; }
        public List<DetalleVentaDto> DetalleVentas { get; set; } = new();
    }
}
