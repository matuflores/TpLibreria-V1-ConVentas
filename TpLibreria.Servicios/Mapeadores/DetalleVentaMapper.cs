using TpLibreria.Entidades;
using TpLibreria.Entidades.Enums;
using TpLibreria.Servicios.DTOs.DetalleVenta;

namespace TpLibreria.Servicios.Mapeadores
{
    public static class DetalleVentaMapper
    {
        public static DetalleVentaDto ToDto(DetalleVenta detalleVenta)
        {
            return new DetalleVentaDto
            {
                LibroId = detalleVenta.LibroId,
                Libro = detalleVenta.Libro.Titulo,
                Tipo = detalleVenta.Libro.Tipo == TipoLibro.Fisico ? "Físico" : "Digital",
                PrecioUnitario = detalleVenta.PrecioUnitario,
                Cantidad = detalleVenta.Cantidad,
                Stock = (detalleVenta.Libro as LibroFisico)?.Stock ?? 0
            };
        }
    }
}
