namespace TpLibreria.Entidades
{
    public class DetalleVenta
    {
        public int DetalleVentaId { get; private set; }

        public int VentaId { get; private set; }
        public Venta Venta { get; private set; } = null!;

        public int LibroId { get; private set; }
        public Libro Libro { get; private set; } = null!;

        public int Cantidad { get; private set; }
        public decimal PrecioUnitario { get; private set; }

        public decimal Subtotal => PrecioUnitario * Cantidad;

        private DetalleVenta() { } // EF Core

        public DetalleVenta(int libroId, int cantidad, decimal precioUnitario)
        {
            if (libroId <= 0)
                throw new ArgumentOutOfRangeException(
                    nameof(libroId));

            if (cantidad <= 0)
                throw new ArgumentOutOfRangeException(
                    nameof(cantidad));

            if (precioUnitario < 0)
                throw new ArgumentOutOfRangeException(
                    nameof(precioUnitario));

            LibroId = libroId;
            Cantidad = cantidad;
            PrecioUnitario = precioUnitario;
        }
    }
}
