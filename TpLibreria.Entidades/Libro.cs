using TpLibreria.Entidades.Enums;
using TpLibreria.Entidades.Interfaces;

namespace TpLibreria.Entidades
{
    // clase base: un libro puede ser físico o digital
    public abstract class Libro : IConcurrencyEntity
    {
        private string _titulo = null!;
        private string? _descripcion;
        private int _anioPublicacion;
        private decimal _precio;
        private int _editorialId;

        public int LibroId { get; set; }

        public string Titulo
        {
            get => _titulo;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("El título es obligatorio.", nameof(value));
                }
                if (value.Trim().Length > 100)
                {
                    throw new ArgumentException("El título no puede superar los 100 caracteres.", nameof(value));
                }
                _titulo = value.Trim();
            }
        }

        public string? Descripcion
        {
            get => _descripcion;
            set
            {
                if (value != null && value.Trim().Length > 250)
                {
                    throw new ArgumentException("La descripcion no puede superar los 250 caracteres.", nameof(value));
                }
                _descripcion = string.IsNullOrWhiteSpace(value) ? null : value.Trim();
            }
        }

        public int AnioPublicacion
        {
            get => _anioPublicacion;
            set
            {
                if (value < 1000 || value > DateTime.Today.Year)
                {
                    throw new ArgumentOutOfRangeException(nameof(value),
                        $"El año de publicación debe estar entre 1000 y {DateTime.Today.Year}.");
                }
                _anioPublicacion = value;
            }
        }

        public decimal Precio
        {
            get => _precio;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "El precio no puede ser negativo.");
                }
                _precio = value;
            }
        }

        public bool Activo { get; set; } = true;

        public byte[] RowVersion { get; set; } = null!;

        public int EditorialId
        {
            get => _editorialId;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "La editorial es obligatoria.");
                }
                _editorialId = value;
            }
        }
        public Editorial Editorial { get; set; } = null!;

        public ICollection<Autor> Autores { get; set; } = new List<Autor>();
        public ICollection<Tema> Temas { get; set; } = new List<Tema>();

        public ICollection<DetalleVenta> Detalles { get; set; } = new List<DetalleVenta>();

        public abstract TipoLibro Tipo { get; }

        public abstract bool TieneStockSuficiente(int cantidad);
        public abstract void DescontarStock(int cantidad);
        public abstract void ReponerStock(int cantidad);
        public abstract string MostrarDatos();

        public bool EsVendible => Activo && Editorial is not null && Editorial.Activo;

        public void AgregarAutor(Autor autor)
        {
            ArgumentNullException.ThrowIfNull(autor);
            if (Autores.Any(a => a.AutorId == autor.AutorId))
            {
                throw new InvalidOperationException($"El autor {autor.NombreCompleto} ya está asociado al libro.");
            }
            Autores.Add(autor);
        }

        public void AgregarTema(Tema tema)
        {
            ArgumentNullException.ThrowIfNull(tema);
            
            if (Temas.Any(t => t.TemaId == tema.TemaId))
            {
                throw new InvalidOperationException($"El tema {tema.Nombre} ya está asociado al libro.");
            }
            Temas.Add(tema);
        }// No se puede asociar dos veces el mismo tema a un mismo libro
    }
}
