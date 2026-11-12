using TpLibreria.Servicios.DTOs.DetalleVenta;
using TpLibreria.Servicios.DTOs.Venta;

namespace TpLibreria.Windows.Classes
{
    //igual al EditorVenta de Carlos
    public class EditorVenta
    {
        private VentaCreateDto _ventaDto = null!;
        public EditorVenta(VentaCreateDto ventaDto)
        {
            _ventaDto = ventaDto;
        }

        public void AgregarLibro(DetalleVentaDto detalleDto)
        {
            if (detalleDto is null) throw new ArgumentNullException(nameof(detalleDto),
                "El detalle no puede ser nulo");
            var detalleEnVenta = _ventaDto.Detalle
                .FirstOrDefault(dv => dv.LibroId == detalleDto.LibroId);
            if (detalleEnVenta is null)
            {
                _ventaDto.Detalle.Add(detalleDto);
                return;
            }
            //carlos suma sin controlar el stock, por loq ue se podia agregar dos veces el mismo producto y exceder la disponibilidad. Aca se controla (solo físicos).
            if (detalleEnVenta.Tipo == "Físico" &&
                detalleEnVenta.Cantidad + detalleDto.Cantidad > detalleEnVenta.Stock)
            {
                throw new InvalidOperationException(
                    $"Stock insuficiente. Disponible: {detalleEnVenta.Stock}, ya cargados: {detalleEnVenta.Cantidad}");
            }
            detalleEnVenta.Cantidad += detalleDto.Cantidad;
        }

        public void EliminarLibro(int libroId)
        {
            if (_ventaDto.Detalle.Count == 1)
            {
                throw new InvalidOperationException("La venta debe tener al menos 1 item");
            }
            if (libroId <= 0)
            {
                throw new ArgumentException("El ID del libro debe ser mayor a cero");
            }
            var detalleEnVenta = _ventaDto.Detalle
                .FirstOrDefault(dv => dv.LibroId == libroId);
            if (detalleEnVenta is null)
            {
                throw new InvalidOperationException($"El libro ID {libroId} no se encuentra en el detalle");
            }
            _ventaDto.Detalle.Remove(detalleEnVenta);
        }

        public void ModificarCantidadDetalle(int libroId, int cantidad)
        {
            if (libroId <= 0)
            {
                throw new ArgumentException("El ID del libro debe ser mayor a cero");
            }
            if (cantidad <= 0)
            {
                throw new ArgumentException("La cantidad debe ser mayor a cero");
            }
            var detalleEnVenta = _ventaDto.Detalle
                .FirstOrDefault(dv => dv.LibroId == libroId);
            if (detalleEnVenta is null)
            {
                throw new InvalidOperationException($"El libro ID {libroId} no se encuentra en el detalle");
            }
            detalleEnVenta.Cantidad = cantidad;
        }

        internal List<DetalleVentaDto> ObtenerDetalles()
        {
            return _ventaDto.Detalle;
        }

        internal (IReadOnlyCollection<DetalleVentaDto> Detalles,
             decimal Total) ObtenerResumen()
        {
            var detalles = _ventaDto.Detalle;
            var total = _ventaDto.Detalle.Sum(d => d.Subtotal);
            return (detalles, total);
        }
    }
}
