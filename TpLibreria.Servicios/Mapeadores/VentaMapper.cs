using TpLibreria.Entidades;
using TpLibreria.Servicios.DTOs.Venta;

namespace TpLibreria.Servicios.Mapeadores
{
    public static class VentaMapper
    {
        public static VentaListDto ToListDto(Venta venta)
        {
            return new VentaListDto
            {
                VentaId = venta.VentaId,
                Fecha = venta.Fecha,
                Cliente = venta.Cliente.NombreCompleto,
                TipoVenta = venta.TipoVenta.ToString(),
                Estado = venta.Estado.ToString(),
                CantidadLibros = venta.Detalles.Sum(d => d.Cantidad),
                ImporteTotal = venta.ImporteTotal
            };
        }

        public static VentaDetailDto ToDetailDto(Venta venta)
        {
            return new VentaDetailDto
            {
                VentaId = venta.VentaId,
                Fecha = venta.Fecha,
                Cliente = venta.Cliente.NombreCompleto,
                TipoVenta = venta.TipoVenta.ToString(),
                Estado = venta.Estado.ToString(),
                ImporteTotal = venta.ImporteTotal,
                DetalleVentas = venta.Detalles
                                .Select(d => DetalleVentaMapper.ToDto(d)).ToList()
            };
        }
    }
}
