using TpLibreria.Entidades;
using System.Linq.Expressions;

namespace TpLibreria.Datos.Interfaces
{
    public interface IAutorRepositorio : IRepositorioConcurrente<Autor>
    {
        bool Existe(Autor autor);
        bool TieneRegistrosRelacionados(int autorId);
        int ObtenerPosicionRegistro(int seleccionadoId,
            Expression<Func<Autor, bool>>? filtrarPor = null);
        List<Autor> ObtenerPorIds(IEnumerable<int> ids);//trae los autores con seguimiento (tracked) para poder asociarlos al libro al crearlo o editarlo
    }
}
