using TpLibreria.Datos.Interfaces;

namespace TpLibreria.Datos
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly LibreriaDbContext _context;
        public IEditorialRepositorio Editoriales { get; }
        public IAutorRepositorio Autores { get; }
        public ITemaRepositorio Temas { get; }
        public ILibroRepositorio Libros { get; }
        public IClienteRepositorio Clientes { get; }
        public IVentaRepositorio Ventas { get; }

        public UnitOfWork(IEditorialRepositorio editorialRepositorio,
            IAutorRepositorio autorRepositorio,
            ITemaRepositorio temaRepositorio,
            ILibroRepositorio libroRepositorio,
            IClienteRepositorio clienteRepositorio,
            IVentaRepositorio ventaRepositorio,
            LibreriaDbContext context)
        {
            Editoriales = editorialRepositorio;
            Autores = autorRepositorio;
            Temas = temaRepositorio;
            Libros = libroRepositorio;
            Clientes = clienteRepositorio;
            Ventas = ventaRepositorio;
            _context = context;
        }

        //usar el savechanges aca me permite que si hay un error en la venta, no me la permita guardar por la mitad. Se guarda todo o no se guarda nada
        public void Save()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
