using TpLibreria.Entidades;
using System.Linq.Expressions;

namespace TpLibreria.Datos.Interfaces
{
    public interface IEditorialRepositorio : IRepositorioConcurrente<Editorial>
    {
        bool Existe(Editorial editorial);
        bool TieneRegistrosRelacionados(int editorialId);
        int ObtenerPosicionRegistro(int seleccionadoId,
            Expression<Func<Editorial, bool>>? filtrarPor = null);
    }
}
