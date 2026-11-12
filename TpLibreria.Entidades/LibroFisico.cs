using TpLibreria.Entidades.Enums;
using System.Text.RegularExpressions;

namespace TpLibreria.Entidades
{
    public class LibroFisico : Libro
    {
        private string _isbn = null!;
        private int _stock;

        public string Isbn
        {
            get => _isbn;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("El ISBN es obligatorio.", nameof(value));
                }
                string isbnLimpio = NormalizarIsbn(value);
                if (!EsIsbnValido(isbnLimpio))
                {
                    throw new ArgumentException("El ISBN debe tener 10 o 13 caracteres (solo números; el último del ISBN-10 puede ser X).", nameof(value));
                }
                _isbn = isbnLimpio;
            }
        }

        
        public int Stock
        {
            get => _stock;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "El stock no puede ser negativo.");
                }
                _stock = value;
            }
        }

        public override TipoLibro Tipo => TipoLibro.Fisico;

        public override bool TieneStockSuficiente(int cantidad)
        {
            return Stock >= cantidad;
        }

        public override void DescontarStock(int cantidad)
        {
            if (!TieneStockSuficiente(cantidad))
            {
                throw new InvalidOperationException(
                    $"Stock insuficiente de \"{Titulo}\". Disponible: {Stock}.");
            }
            Stock -= cantidad;
        }

        public override void ReponerStock(int cantidad)
        {
            Stock += cantidad;
        }

        public override string MostrarDatos()
        {
            return $"Libro físico: {Titulo} - ISBN: {Isbn} - Precio: {Precio:C2} - Stock: {Stock}";
        }

        public static string NormalizarIsbn(string isbn)
        {
            return isbn.Replace("-", "").Replace(" ", "").Trim().ToUpperInvariant();
        }

        public static bool EsIsbnValido(string isbnNormalizado)
        {
            return Regex.IsMatch(isbnNormalizado, @"^(\d{13}|\d{9}[\dX])$");//
        }
    }
}
