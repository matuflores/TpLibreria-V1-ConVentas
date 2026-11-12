using TpLibreria.Entidades.Interfaces;

namespace TpLibreria.Entidades
{
    public class Editorial : IConcurrencyEntity
    {
        public int EditorialId { get; set; }

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
                if (value.Trim().Length > 100)
                {
                    throw new ArgumentException("El nombre no puede superar los 100 caracteres.", nameof(value));
                }
                _nombre = value.Trim();
            }
        }

        private string _paisOrigen = null!;
        public string PaisOrigen
        {
            get => _paisOrigen;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("El país de origen es obligatorio.", nameof(value));
                }
                if (value.Trim().Length > 50)
                {
                    throw new ArgumentException("El país de origen no puede superar los 50 caracteres.", nameof(value));
                }
                _paisOrigen = value.Trim();
            }
        }

        public bool Activo { get; set; } = true;

        public byte[] RowVersion { get; set; } = null!;

        public ICollection<Libro> Libros { get; set; } = new List<Libro>();
    }
}
