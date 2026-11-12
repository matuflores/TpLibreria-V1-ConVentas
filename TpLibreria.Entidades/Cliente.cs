using TpLibreria.Entidades.Interfaces;
using System.Text.RegularExpressions;

namespace TpLibreria.Entidades
{
    public class Cliente : IConcurrencyEntity
    {
        public int ClienteId { get; set; }

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

        private string _email = null!;
        public string Email
        {
            get => _email;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("El email es obligatorio.", nameof(value));
                }
                if (value.Trim().Length > 100)
                {
                    throw new ArgumentException("El email no puede superar los 100 caracteres.", nameof(value));
                }
                if (!Regex.IsMatch(value.Trim(), @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                {
                    throw new ArgumentException("El email no tiene un formato válido.", nameof(value));
                }
                _email = value.Trim();
            }
        }

        private string? _telefono;
        public string? Telefono
        {
            get => _telefono;
            set
            {
                if (value != null && value.Trim().Length > 20)
                {
                    throw new ArgumentException("El teléfono no puede superar los 20 caracteres.", nameof(value));
                }
                _telefono = string.IsNullOrWhiteSpace(value) ? null : value.Trim();
            }
        }

        public byte[] RowVersion { get; set; } = null!;

        public ICollection<Venta> Ventas { get; set; } = new List<Venta>();

        public string NombreCompleto => $"{Apellido}, {Nombre}";
    }
}
