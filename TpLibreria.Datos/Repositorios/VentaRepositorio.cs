using TpLibreria.Datos.Interfaces;
using TpLibreria.Entidades;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace TpLibreria.Datos.Repositorios
{
    public class VentaRepositorio : RepositorioConcurrente<Venta>, IVentaRepositorio
    {
        public VentaRepositorio(LibreriaDbContext context) : base(context)
        {
        }

        // nuevo
        public Venta? ObtenerPorId(int ventaId, bool tracked = false)
        {
            IQueryable<Venta> query = _context.Ventas
                .Include(v => v.Cliente)
                .Include(v => v.Detalles)
                    .ThenInclude(d => d.Libro)
                        .ThenInclude(l => l.Editorial);
            if (tracked)
            {
                return query.FirstOrDefault(v => v.VentaId == ventaId);
            }
            return query
                .AsNoTracking()
                .FirstOrDefault(v => v.VentaId == ventaId);
        }

        public int ObtenerPosicionRegistro(int seleccionadoId,
            Expression<Func<Venta, bool>>? filtrarPor = null)
        {
            var enDb = _context.Ventas
                .AsNoTracking()
                .FirstOrDefault(v => v.VentaId == seleccionadoId);
            if (enDb is null) return 0;
            var query = Query();
            if (filtrarPor is not null)
            {
                query = query.Where(filtrarPor);
            }
            
            return query.Count(v => v.Fecha > enDb.Fecha ||
                (v.Fecha == enDb.Fecha && v.VentaId >= enDb.VentaId));// El listado se ordena por fecha descendente
        }
    }
}
