using TpLibreria.Entidades.Enums;
using TpLibreria.Entidades.Interfaces;

namespace TpLibreria.Entidades
{
    public class Venta : IConcurrencyEntity
    {
        private readonly List<DetalleVenta> _detalles = new();

        public int VentaId { get; private set; }

        public int ClienteId { get; private set; }
        public Cliente Cliente { get; private set; } = null!;

        public DateTime Fecha { get; private set; }
        public TipoVenta TipoVenta { get; private set; }
        public EstadoVenta Estado { get; private set; }
        public decimal ImporteTotal { get; private set; }
        public byte[] RowVersion { get; set; } = null!;

        
        public IReadOnlyCollection<DetalleVenta> Detalles =>
            _detalles.AsReadOnly();//el IREADONLY es para que no se pueda modificar la lista desde afuera de la entidad, solo se puede modificar desde adentro de la entidad, con el método AgregarDetalle

        private Venta() { } // EF Core

        public Venta(int clienteId, TipoVenta tipoVenta)
        {
            
            if (clienteId <= 0)//cambie que carlos valida mayor a 0 y yo que sea mayor o igual a 0, porque no existe un cliente con id 0, y si se pasa un id 0 es un error
                throw new ArgumentOutOfRangeException(
                    nameof(clienteId));
            if (!Enum.IsDefined(tipoVenta))
                throw new ArgumentOutOfRangeException(
                    nameof(tipoVenta));

            ClienteId = clienteId;
            TipoVenta = tipoVenta;
            Fecha = DateTime.Now;
            
            //Toda venta nace Pendiente y despues se factura o se anula
            Estado = EstadoVenta.Pendiente;
        }

        public void AgregarDetalle(int libroId, int cantidad, decimal precio)
        {
            if (_detalles.Any(d => d.LibroId == libroId))
                throw new InvalidOperationException(
                    $"El libro con ID {libroId} ya está incluido en la venta.");
            var detalle = new DetalleVenta(
                libroId, cantidad, precio);

            _detalles.Add(detalle);

            ImporteTotal = _detalles.Sum(d => d.Subtotal);
        }

        
        public void Facturar()
        {
            if (Estado != EstadoVenta.Pendiente)
                throw new InvalidOperationException(
                    "Solamente se pueden facturar ventas pendientes.");

            if (!_detalles.Any())
                throw new InvalidOperationException(
                    "No se puede facturar una venta sin detalles.");

            Estado = EstadoVenta.Facturada;
        }

        // Solo se anulan ventas pendientes y la devolución del stock la hace el servicio *VentaServicio.AnularVenta*
        public void Anular()
        {
            if (Estado != EstadoVenta.Pendiente)
                throw new InvalidOperationException(
                    "Solamente se pueden anular vents pendientes.");

            Estado = EstadoVenta.Anulada;
        }
    }
}
