using TpLibreria.Datos.Interfaces;

namespace TpLibreria.Datos
{
    public interface IUnitOfWork : IDisposable
    {
        IEditorialRepositorio Editoriales { get; }
        IAutorRepositorio Autores { get; }
        ITemaRepositorio Temas { get; }
        ILibroRepositorio Libros { get; }
        IClienteRepositorio Clientes { get; }
        IVentaRepositorio Ventas { get; }
        void Save();
    }
}
