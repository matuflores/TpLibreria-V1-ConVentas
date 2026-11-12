using TpLibreria.Datos.Interfaces;
using TpLibreria.Entidades;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace TpLibreria.Datos.Repositorios
{
    public class ClienteRepositorio : RepositorioConcurrente<Cliente>, IClienteRepositorio
    {
        public ClienteRepositorio(LibreriaDbContext context) : base(context)
        {
        }

        public bool TieneRegistrosRelacionados(int clienteId)
        {
            return _context.Ventas.Any(v => v.ClienteId == clienteId);
        }

        public bool Existe(Cliente cliente)
        {
            return _context.Clientes.Any(c => c.Email == cliente.Email && c.ClienteId != cliente.ClienteId);
        }

        public override Cliente? ObtenerPorId(int id)
        {
            return _context.Clientes
                .AsNoTracking()
                .FirstOrDefault(x => x.ClienteId == id);
        }

        public int ObtenerPosicionRegistro(int seleccionadoId,
            Expression<Func<Cliente, bool>>? filtrarPor = null)
        {
            var enDb = ObtenerPorId(seleccionadoId);
            if (enDb is null) return 0;
            var query = Query();
            if (filtrarPor is not null)
            {
                query = query.Where(filtrarPor);
            }
            return query.Count(c => string.Compare(c.Apellido, enDb.Apellido) < 0 || (c.Apellido == enDb.Apellido && string.Compare(c.Nombre, enDb.Nombre) <= 0));
        }
    }
}
