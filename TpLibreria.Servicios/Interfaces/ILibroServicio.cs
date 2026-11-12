using TpLibreria.Servicios.Common;
using TpLibreria.Servicios.DTOs.Libro;

namespace TpLibreria.Servicios.Interfaces
{
    public interface ILibroServicio
    {
        Result<List<LibroListDto>> ObtenerTodos();
        Result<ResultadoPaginacionDto<LibroListDto>> ObtenerPagina(int pagina,
            int cantidad, string campoOrdenar, bool esAscendente,
            bool? filtroActivo = null, string? textoBuscar = null);//esto es para la grilla de libros, que solo muestra los libros activos y de editoriales activas siempre y cuando no se indique un filtro de activos
        Result<LibroListDto> ObtenerPorId(int id);
        Result<LibroUpdateDto> ObtenerParaEditar(int id);
        Result<LibroDeleteDto> ObtenerParaBorrar(int id);
        Result<int> Agregar(LibroCreateDto libroDto);
        Result Editar(LibroUpdateDto libroDto);
        Result Borrar(LibroDeleteDto libroDto);
        Result<int> ObtenerPaginaRegistro(int seleccionadoId, int cantidadPorPagina,
            bool? filtroActivo = null, string? textoBuscar = null);
        Result<List<LibroComboDto>> ObtenerDatosCombo();
    }
}
