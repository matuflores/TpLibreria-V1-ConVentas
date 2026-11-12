using TpLibreria.Entidades.Enums;
using TpLibreria.Servicios.Common;
using TpLibreria.Servicios.DTOs.Cliente;

namespace TpLibreria.Servicios.Interfaces
{
    public interface IClienteServicio
    {
        Result<List<ClienteListDto>> ObtenerTodos();
        Result<ClienteListDto> ObtenerPorId(int id);
        Result<ClienteUpdateDto> ObtenerParaEditar(int id);
        Result<ClienteDeleteDto> ObtenerParaBorrar(int id);

        Result<int> Agregar(ClienteCreateDto clienteDto);
        Result Editar(ClienteUpdateDto clienteDto);
        Result Borrar(ClienteDeleteDto clienteDto);
        Result<ResultadoPaginacionDto<ClienteListDto>> ObtenerPagina(int pagina,
            int cantidad, string campoOrdenar, bool esAscendente,
            string? textoBuscar = null);
        Result<int> ObtenerPaginaRegistro(int seleccionadoId, int cantidadPorPagina,
            string? textoBuscar = null);
        
        Result<List<ClienteComboDto>> ObtenerDatosCombo(ClienteDefault defaultCliente);// Datos para llenar combos o listas de selección
    }
}
