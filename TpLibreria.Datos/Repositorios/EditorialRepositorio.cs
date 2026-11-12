using TpLibreria.Datos.Interfaces;
using TpLibreria.Entidades;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace TpLibreria.Datos.Repositorios
{
    public class EditorialRepositorio : RepositorioConcurrente<Editorial>, IEditorialRepositorio
    {
        public EditorialRepositorio(LibreriaDbContext context) : base(context)
        {
        }

        public bool TieneRegistrosRelacionados(int editorialId)
        {
            return _context.Libros.Any(l => l.EditorialId == editorialId);
        }

        public bool Existe(Editorial editorial)
        {
            return _context.Editoriales.Any(e => e.Nombre == editorial.Nombre && e.EditorialId != editorial.EditorialId);
        }

        public override Editorial? ObtenerPorId(int id)
        {
            return _context.Editoriales
                .AsNoTracking()
                .FirstOrDefault(x => x.EditorialId == id);
        }

        public int ObtenerPosicionRegistro(int seleccionadoId,
            Expression<Func<Editorial, bool>>? filtrarPor = null)
        {
            var enDb = ObtenerPorId(seleccionadoId);
            if (enDb is null) return 0;
            var query = Query();
            if (filtrarPor is not null)
            {
                query = query.Where(filtrarPor);
            }
            return query.Count(e => string.Compare(e.Nombre, enDb.Nombre) <= 0);
        }
    }
}
