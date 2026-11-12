using TpLibreria.Datos.Interfaces;
using TpLibreria.Entidades;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace TpLibreria.Datos.Repositorios
{
    public class AutorRepositorio : RepositorioConcurrente<Autor>, IAutorRepositorio
    {
        public AutorRepositorio(LibreriaDbContext context) : base(context)
        {
        }

        public bool TieneRegistrosRelacionados(int autorId)
        {
            return _context.Libros.Any(l => l.Autores.Any(a => a.AutorId == autorId));
        }

        public bool Existe(Autor autor)
        {
            return _context.Autores.Any(a => a.Nombre == autor.Nombre && a.Apellido == autor.Apellido && a.FechaNacimiento == autor.FechaNacimiento && a.AutorId != autor.AutorId);
        }

        public override Autor? ObtenerPorId(int id)
        {
            return _context.Autores
                .AsNoTracking()
                .FirstOrDefault(x => x.AutorId == id);
        }

        public int ObtenerPosicionRegistro(int seleccionadoId,
            Expression<Func<Autor, bool>>? filtrarPor = null)
        {
            var enDb = ObtenerPorId(seleccionadoId);
            if (enDb is null) return 0;
            var query = Query();
            if (filtrarPor is not null)
            {
                query = query.Where(filtrarPor);
            }
            return query.Count(a => string.Compare(a.Apellido, enDb.Apellido) < 0 || (a.Apellido == enDb.Apellido && string.Compare(a.Nombre, enDb.Nombre) <= 0));
        }

        public List<Autor> ObtenerPorIds(IEnumerable<int> ids)
        {
            var listaIds = ids.Distinct().ToList();
            return _context.Autores
                .Where(x => listaIds.Contains(x.AutorId))
                .ToList();
        }
    }
}
