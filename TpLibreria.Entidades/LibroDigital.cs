using TpLibreria.Entidades.Enums;

namespace TpLibreria.Entidades
{
    public class LibroDigital : Libro
    {
        private string _identificador = null!;
        private string _formato = null!;
        private long _tamanoArchivo;
        private string _urlDescarga = null!;

        public string Identificador
        {
            get => _identificador;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("El identificador es obligatorio.", nameof(value));
                }
                if (value.Trim().Length > 50)
                {
                    throw new ArgumentException("El identificador no puede superar los 50 caracteres.", nameof(value));
                }
                _identificador = value.Trim();
            }
        }

        public string Formato
        {
            get => _formato;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("El formato es obligatorio.", nameof(value));
                }
                if (value.Trim().Length > 20)
                {
                    throw new ArgumentException("El formato no puede superar los 20 caracteres.", nameof(value));
                }
                _formato = value.Trim().ToUpperInvariant();
            }
        }

        
        public long TamanoArchivo
        {
            get => _tamanoArchivo;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "El tamaño del archivo debe ser mayor que cero.");
                }
                _tamanoArchivo = value;
            }
        }

        public string UrlDescarga
        {
            get => _urlDescarga;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("La URL de descarga es obligatoria.", nameof(value));
                }
                if (value.Trim().Length > 250)
                {
                    throw new ArgumentException("La URL de descarga no puede superar los 250 caracteres.", nameof(value));
                }
                if (!Uri.TryCreate(value.Trim(), UriKind.Absolute, out var uri) ||
                    (uri.Scheme != Uri.UriSchemeHttp && uri.Scheme != Uri.UriSchemeHttps))
                {
                    throw new ArgumentException("La URL de descarga no es válida.", nameof(value));
                }
                _urlDescarga = value.Trim();
            }
        }

        public override TipoLibro Tipo => TipoLibro.Digital;

        
        public override bool TieneStockSuficiente(int cantidad)
        {
            return true;
        }
        //metodos sin usos solo porque no se controla el stock en libros digitales, pero como son abstractos hay que implementarlos aunque no se usen
        public override void DescontarStock(int cantidad)
        {
        }

        public override void ReponerStock(int cantidad)
        {
        }

        public override string MostrarDatos()
        {
            return $"Libro digital: {Titulo} - Formato: {Formato} - Precio: {Precio:C2}";
        }
    }
}
