using TpLibreria.Entidades.Interfaces;

namespace TpLibreria.Entidades
{
    public class Autor : IConcurrencyEntity
    {
        public int AutorId { get; set; }

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

        private string _apellido = null!;
        public string Apellido
        {
            get => _apellido;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("El apellido es obligatorio.", nameof(value));
                }
                if (value.Trim().Length > 50)
                {
                    throw new ArgumentException("El apellido no puede superar los 50 caracteres.", nameof(value));
                }
                _apellido = value.Trim();
            }
        }

        private DateTime _fechaNacimiento;
        public DateTime FechaNacimiento
        {
            get => _fechaNacimiento;
            set
            {
                if (value.Date > DateTime.Today)
                {
                    throw new ArgumentException("La fecha de nacimiento no puede ser futura.", nameof(value));
                }
                if (value.Date < new DateTime(1753, 1, 1))
                {
                    throw new ArgumentException("La fecha de nacimiento no es válida.", nameof(value));
                }
                _fechaNacimiento = value.Date;
            }
        }

        private string _nacionalidad = null!;
        public string Nacionalidad
        {
            get => _nacionalidad;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("La nacionalidad es obligatoria.", nameof(value));
                }
                if (value.Trim().Length > 50)
                {
                    throw new ArgumentException("La nacionalidad no puede superar los 50 caracteres.", nameof(value));
                }
                _nacionalidad = value.Trim();
            }
        }

        public byte[] RowVersion { get; set; } = null!;

        public ICollection<Libro> Libros { get; set; } = new List<Libro>();

        public string NombreCompleto => $"{Apellido}, {Nombre}";
    }
}
