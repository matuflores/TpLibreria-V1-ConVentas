using TpLibreria.Entidades.Enums;
using TpLibreria.Servicios.Common;
using TpLibreria.Servicios.DTOs.Venta;

namespace TpLibreria.Servicios.Interfaces
{
    public interface IVentaServicio
    {
        Result<ResultadoPaginacionDto<VentaListDto>> ObtenerPagina(int pagina,
            int cantidad, string campoOrdenar, bool esAscendente,
            EstadoVenta? filtroEstado = null, string? textoBuscar = null);
        Result<VentaDetailDto?> ObtenerPorId(int ventaId);
        Result<int> Agregar(VentaCreateDto ventaDto);
        Result Facturar(int ventaId);
        Result AnularVenta(int ventaId);
        Result<int> ObtenerPaginaRegistro(int seleccionadoId, int cantidadPorPagina,
            EstadoVenta? filtroEstado = null, string? textoBuscar = null);
    }
}
