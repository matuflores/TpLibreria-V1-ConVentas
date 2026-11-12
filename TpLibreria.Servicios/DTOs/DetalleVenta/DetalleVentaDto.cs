using System.ComponentModel;

namespace TpLibreria.Servicios.DTOs.DetalleVenta
{
    public class DetalleVentaDto
    {
        public int LibroId { get; set; }
        public string Libro { get; set; } = null!;
        public string Tipo { get; set; } = null!;
        public decimal PrecioUnitario { get; set; }
        public int Cantidad { get; set; }
        // Agregado para el control cuando se modifica la cantidad (los libros digitales no tienen stock)
        [Browsable(false)]
        public int Stock { get; set; }
        public decimal Subtotal => PrecioUnitario * Cantidad;
    }
}
