using TpLibreria.Datos.Interfaces;
using TpLibreria.Entidades;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace TpLibreria.Datos.Repositorios
{
    public class TemaRepositorio : RepositorioConcurrente<Tema>, ITemaRepositorio
    {
        public TemaRepositorio(LibreriaDbContext context) : base(context)
        {
        }

        public bool TieneRegistrosRelacionados(int temaId)
        {
            return _context.Libros.Any(l => l.Temas.Any(t => t.TemaId == temaId));
        }

        public bool Existe(Tema tema)
        {
            return _context.Temas.Any(t => t.Nombre == tema.Nombre && t.TemaId != tema.TemaId);
        }

        public override Tema? ObtenerPorId(int id)
        {
            return _context.Temas
                .AsNoTracking()
                .FirstOrDefault(x => x.TemaId == id);
        }

        public int ObtenerPosicionRegistro(int seleccionadoId,
            Expression<Func<Tema, bool>>? filtrarPor = null)
        {
            var enDb = ObtenerPorId(seleccionadoId);
            if (enDb is null) return 0;
            var query = Query();
            if (filtrarPor is not null)
            {
                query = query.Where(filtrarPor);
            }
            return query.Count(t => string.Compare(t.Nombre, enDb.Nombre) <= 0);
        }

        public List<Tema> ObtenerPorIds(IEnumerable<int> ids)
        {
            var listaIds = ids.Distinct().ToList();
            return _context.Temas
                .Where(x => listaIds.Contains(x.TemaId))
                .ToList();
        }
    }
}
