using TpLibreria.Entidades.Interfaces;

namespace TpLibreria.Entidades
{
    public class Tema : IConcurrencyEntity
    {
        public int TemaId { get; set; }

        private string _nombre = null!;
        public string Nombre
        {
            get => _nombre;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("El nombre es obligatorio.", nameof(value));
                }
                if (value.Trim().Length > 50)
                {
                    throw new ArgumentException("El nombre no puede superar los 50 caracteres.", nameof(value));
                }
                _nombre = value.Trim();
            }
        }

        private string? _descripcion;
        public string? Descripcion
        {
            get => _descripcion;
            set
            {
                if (value != null && value.Trim().Length > 150)
                {
                    throw new ArgumentException("La descripción no puede superar los 150 caracteres.", nameof(value));
                }
                _descripcion = string.IsNullOrWhiteSpace(value) ? null : value.Trim();
            }
        }

        public byte[] RowVersion { get; set; } = null!;

        public ICollection<Libro> Libros { get; set; } = new List<Libro>();
    }
}
