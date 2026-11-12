using TpLibreria.Entidades.Enums;
using TpLibreria.Servicios.Common;
using TpLibreria.Servicios.DTOs.Autor;

namespace TpLibreria.Servicios.Interfaces
{
    public interface IAutorServicio
    {
        Result<List<AutorListDto>> ObtenerTodos();
        Result<AutorListDto> ObtenerPorId(int id);
        Result<AutorUpdateDto> ObtenerParaEditar(int id);
        Result<AutorDeleteDto> ObtenerParaBorrar(int id);

        Result<int> Agregar(AutorCreateDto autorDto);
        Result Editar(AutorUpdateDto autorDto);
        Result Borrar(AutorDeleteDto autorDto);
        Result<ResultadoPaginacionDto<AutorListDto>> ObtenerPagina(int pagina,
            int cantidad, string campoOrdenar, bool esAscendente,
            string? textoBuscar = null);
        Result<int> ObtenerPaginaRegistro(int seleccionadoId, int cantidadPorPagina,
            string? textoBuscar = null);
        Result<List<AutorComboDto>> ObtenerDatosCombo();//datos de todos los autores (para llenar un combo o lista de selección)
        Result<List<AutorComboDto>> ObtenerPorIds(List<int> ids);// Datos de los autores ya elegidos (para mostrarlos en la lista de un libro)
    }
}
