using TpLibreria.Entidades.Enums;
using TpLibreria.Servicios.DTOs.DetalleVenta;

namespace TpLibreria.Servicios.DTOs.Venta
{
    public class VentaCreateDto
    {
        public int ClienteId { get; set; }
        public TipoVenta TipoVenta { get; set; }
        public decimal Total { get; set; }
        public List<DetalleVentaDto> Detalle { get; set; } = new();
    }
}
