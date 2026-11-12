using TpLibreria.Entidades;
using System.Linq.Expressions;

namespace TpLibreria.Datos.Interfaces
{
    public interface ILibroRepositorio : IRepositorioConcurrente<Libro>
    {
        bool Existe(Libro libro);
        Libro? ObtenerPorId(int libroId, bool tracked = false);
        bool TieneRegistrosRelacionados(int libroId);
        int ObtenerPosicionRegistro(int seleccionadoId, Expression<Func<Libro, bool>>? filtrarPor = null);
    }
}
