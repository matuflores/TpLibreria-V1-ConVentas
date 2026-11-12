using TpLibreria.Entidades;
using System.Linq.Expressions;

namespace TpLibreria.Datos.Interfaces
{
    public interface IVentaRepositorio : IRepositorioConcurrente<Venta>
    {
        Venta? ObtenerPorId(int ventaId, bool tracked = false);
        int ObtenerPosicionRegistro(int seleccionadoId, Expression<Func<Venta, bool>>? filtrarPor = null);
    }
}
