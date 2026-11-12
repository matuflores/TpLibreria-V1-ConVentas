using TpLibreria.Datos.Interfaces;
using TpLibreria.Entidades;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace TpLibreria.Datos.Repositorios
{
    public class LibroRepositorio : RepositorioConcurrente<Libro>, ILibroRepositorio
    {
        public LibroRepositorio(LibreriaDbContext context) : base(context)
        {
        }

        public bool TieneRegistrosRelacionados(int libroId)
        {
            return _context.DetallesVenta
                .Any(d => d.LibroId == libroId);
        }

        public bool Existe(Libro libro)
        {
            return libro switch
            {
                LibroFisico fisico => _context.LibrosFisicos
                    .Any(l => l.Isbn == fisico.Isbn && l.LibroId != fisico.LibroId),
                LibroDigital digital => _context.LibrosDigitales
                    .Any(l => l.Identificador == digital.Identificador && l.LibroId != digital.LibroId),
                _ => false
            };
        }

        public override List<Libro> ObtenerTodos()
        {
            return _context.Libros
                .Include(l => l.Editorial)
                .Include(l => l.Autores)
                .AsNoTracking()
                .ToList();
        }

        //esto nuevo que agrego carlos sobre el tracked. Al menos que se edite o venda no se va hacer el tracked por defecto.
        public Libro? ObtenerPorId(int libroId, bool tracked = false)
        {
            IQueryable<Libro> query = _context.Libros
                .Include(l => l.Editorial)
                .Include(l => l.Autores)
                .Include(l => l.Temas);
            if (tracked)
            {
                return query.FirstOrDefault(l => l.LibroId == libroId);
            }
            return query
                .AsNoTracking()
                .FirstOrDefault(l => l.LibroId == libroId);
        }

        public int ObtenerPosicionRegistro(int seleccionadoId,
            Expression<Func<Libro, bool>>? filtrarPor = null)
        {
            var enDb = _context.Libros
                .AsNoTracking()
                .FirstOrDefault(l => l.LibroId == seleccionadoId);
            if (enDb is null) return 0;
            var query = Query();
            if (filtrarPor is not null)
            {
                query = query.Where(filtrarPor);
            }
            return query.Count(l => string.Compare(l.Titulo, enDb.Titulo) <= 0);
        }
    }
}
