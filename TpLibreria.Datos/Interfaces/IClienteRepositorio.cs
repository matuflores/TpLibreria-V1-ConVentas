using TpLibreria.Entidades;
using System.Linq.Expressions;

namespace TpLibreria.Datos.Interfaces
{
    public interface IClienteRepositorio : IRepositorioConcurrente<Cliente>
    {
        bool Existe(Cliente cliente);
        bool TieneRegistrosRelacionados(int clienteId);
        int ObtenerPosicionRegistro(int seleccionadoId,
            Expression<Func<Cliente, bool>>? filtrarPor = null);
    }
}
