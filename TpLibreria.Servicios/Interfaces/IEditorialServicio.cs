using TpLibreria.Entidades.Enums;
using TpLibreria.Servicios.Common;
using TpLibreria.Servicios.DTOs.Editorial;

namespace TpLibreria.Servicios.Interfaces
{
    public interface IEditorialServicio
    {
        Result<List<EditorialListDto>> ObtenerTodos();
        Result<EditorialListDto> ObtenerPorId(int id);
        Result<EditorialUpdateDto> ObtenerParaEditar(int id);
        Result<EditorialDeleteDto> ObtenerParaBorrar(int id);

        Result<int> Agregar(EditorialCreateDto editorialDto);
        Result Editar(EditorialUpdateDto editorialDto);
        Result Borrar(EditorialDeleteDto editorialDto);
        Result<List<EditorialListDto>> FiltrarPorActivo(bool activo);
        Result<ResultadoPaginacionDto<EditorialListDto>> ObtenerPagina(int pagina,
            int cantidad, string campoOrdenar, bool esAscendente,
            bool? filtroActivo = null, string? textoBuscar = null);
        Result<int> ObtenerPaginaRegistro(int seleccionadoId, int cantidadPorPagina,
            bool? filtroActivo = null, string? textoBuscar = null);
        
        Result<List<EditorialComboDto>> ObtenerDatosCombo(bool soloActivas = true, int? incluirId = null);// Datos para llenar combos o listas de selección
    }
}
