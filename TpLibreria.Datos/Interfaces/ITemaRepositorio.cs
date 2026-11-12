using TpLibreria.Entidades;
using System.Linq.Expressions;

namespace TpLibreria.Datos.Interfaces
{
    public interface ITemaRepositorio : IRepositorioConcurrente<Tema>
    {
        bool Existe(Tema tema);
        bool TieneRegistrosRelacionados(int temaId);
        int ObtenerPosicionRegistro(int seleccionadoId,
            Expression<Func<Tema, bool>>? filtrarPor = null);
        List<Tema> ObtenerPorIds(IEnumerable<int> ids);
    }
}
