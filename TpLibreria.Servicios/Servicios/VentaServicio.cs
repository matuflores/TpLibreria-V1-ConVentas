using TpLibreria.Datos;
using TpLibreria.Entidades;
using TpLibreria.Entidades.Enums;
using TpLibreria.Servicios.Common;
using TpLibreria.Servicios.DTOs.Venta;
using TpLibreria.Servicios.Interfaces;
using TpLibreria.Servicios.Mapeadores;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace TpLibreria.Servicios.Servicios
{
    public class VentaServicio : IVentaServicio
    {
        private readonly IUnitOfWork _unitOfWork;
        public VentaServicio(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        //se validan todos los datos y se juntan los errores en una lista
        public Result<int> Agregar(VentaCreateDto ventaDto)
        {
            if (ventaDto is null)
            {
                return Result<int>.Failure("No se puede agregar una venta nula.");
            }
            var errores = new List<string>();

            var cliente = _unitOfWork.Clientes.ObtenerPorId(ventaDto.ClienteId);
            if (cliente is null)
            {
                errores.Add("El cliente no existe.");
            }

            // se agrego Presencial u Online
            if (!Enum.IsDefined(ventaDto.TipoVenta))
            {
                errores.Add("El tipo de venta no es valido.");
            }

            if (ventaDto.Detalle is null || ventaDto.Detalle.Count == 0)
            {
                errores.Add("La venta debe tener al menos un detalle");
            }
            else
            {
                foreach (var itemDetalle in ventaDto.Detalle)
                {
                    if (itemDetalle.LibroId <= 0)
                    {
                        errores.Add("El Id del libro en el detalle no puede ser menor o igual a cero.");
                        continue;
                    }
                    // Solo se consulta 
                    var libro = _unitOfWork.Libros.ObtenerPorId(itemDetalle.LibroId);
                    if (libro is null)
                    {
                        errores.Add($"El libro con Id {itemDetalle.LibroId} no existe.");
                        continue;
                    }
                    if (itemDetalle.Cantidad <= 0)
                    {
                        errores.Add($"La cantidad del libro {libro.Titulo} debe ser mayor a cero.");
                    }
                    if (!libro.Activo)
                    {
                        errores.Add($"El libro {libro.Titulo} no está activo.");
                    }
                    else if (!libro.Editorial.Activo)
                    {
                        errores.Add($"La editorial {libro.Editorial.Nombre} está inactiva: " +
                            $"el libro {libro.Titulo} no se puede vender.");
                    }
                    // Solo los libros físicos tienen stock (en los digitales siempre da true)
                    else if (!libro.TieneStockSuficiente(itemDetalle.Cantidad))
                    {
                        var fisico = (LibroFisico)libro;
                        errores.Add(
                            $"Stock insuficiente de {libro.Titulo}. " +
                            $"Disponible: {fisico.Stock}, " +
                            $"solicitado: {itemDetalle.Cantidad}.");
                    }
                }
            }
            if (errores.Count > 0)
            {
                return Result<int>.Failure(errores);
            }
            try
            {
                Venta venta = new Venta(ventaDto.ClienteId, ventaDto.TipoVenta);
                foreach (var itemDetalle in ventaDto.Detalle!)
                {
                    // Si con seguimiento, se le va a descontar el stock
                    var libro = _unitOfWork.Libros.ObtenerPorId(itemDetalle.LibroId, true);
                    if (libro is null)
                    {
                        return Result<int>.Failure($"El libro con Id {itemDetalle.LibroId} no existe.");
                    }
                    //carlos guarda el precio que viene en el Dto (frm). Aca lo que tuve que hacer es tomar el precio del libro que viene de la base de datos, asi nadie puede alterar el precio de venta desde afuera.
                    venta.AgregarDetalle(libro.LibroId, itemDetalle.Cantidad, libro.Precio);
                }
                foreach (var itemDetalle in venta.Detalles)
                {
                    // carlos busca el producto con ObtenerPorId(id) como su ObtenerPorId ahora NO hace seguimiento por defecto, el Stock -= cantidad se hace sobre un objeto que EF no controla y el cambio nunca llega a la base.
                    //pido el tracked: true para que EF haga seguimiento del objeto y pueda descontar el stock del libro fisico, si es que es fisico. Si es digital no hace nada.
                    var libro = _unitOfWork.Libros.ObtenerPorId(itemDetalle.LibroId, true);
                    if (libro is null)
                    {
                        return Result<int>.Failure($"El libro con Id {itemDetalle.LibroId} no existe.");
                    }
                    // Polimorfismo: el libro físico descuenta stock, el digital no hace nada
                    libro.DescontarStock(itemDetalle.Cantidad);
                }

                _unitOfWork.Ventas.Agregar(venta);
                _unitOfWork.Save();
                return Result<int>.Success(venta.VentaId);
            }
            catch (DbUpdateConcurrencyException)
            {
                return Result<int>.Failure(
                    "Otro usuario modificó el stock de uno o más libros. Actualice los datos e intente nuevamente.");
            }
            catch (DbUpdateException ex)
            {
                return Result<int>.Failure(
                    $"No se pudo registrar la venta: {ex.GetBaseException().Message}");
            }
            catch (InvalidOperationException ex)
            {
                return Result<int>.Failure(ex.Message);
            }
            catch (Exception ex)
            {
                return Result<int>.Failure(
                    $"Error al registrar la venta: {ex.Message}");
            }
        }

        //el facturar solo cambia el estado de la venta, no toca el stock. El stock se descuenta al vender, y se repone al anular.
        //se trae la venta con tracked: true, si no EF no guarda el cambio de estado (en el Facturar del carlos falta, igual que en su AnularVenta).
        public Result Facturar(int ventaId)
        {
            if (ventaId <= 0)
                return Result.Failure("El ID de venta es inválido.");

            try
            {
                var venta = _unitOfWork.Ventas.ObtenerPorId(ventaId, true);

                if (venta is null)
                    return Result.Failure(
                        $"No existe la venta ID {ventaId}.");

                if (venta.Estado != EstadoVenta.Pendiente)
                    return Result.Failure(
                        "Solamente se pueden facturar ventas pendientes.");

                if (!venta.Detalles.Any())
                    return Result.Failure(
                        "La venta no contiene detalles.");

                venta.Facturar();

                _unitOfWork.Save();

                return Result.Success();
            }
            catch (DbUpdateConcurrencyException)
            {
                return Result.ConcurrencyFailure(
                    "Otro usuario modificó esta venta.\n" +
                    "La grilla se recargará automáticamente");
            }
            catch (DbUpdateException)
            {
                return Result.Failure(
                    "Ocurrió un error al facturar la venta.");
            }
            catch (Exception ex)
            {
                return Result.Failure($"Error al intentar facturar la venta: {ex.Message}");
            }
        }

        public Result AnularVenta(int ventaId)
        {
            if (ventaId <= 0)
                return Result.Failure("El ID de venta es inválido.");

            try
            {

                //hago que el ObtenerPorId de la venta traiga el tracked: true, porque si no EF no guarda el cambio de estado.
                var venta = _unitOfWork.Ventas.ObtenerPorId(ventaId, true);

                if (venta is null)
                    return Result.Failure(
                        $"No existe la venta ID {ventaId}.");

                if (venta.Estado != EstadoVenta.Pendiente)
                    return Result.Failure(
                        "Solamente se pueden anular ventas pendientes.");

                if (!venta.Detalles.Any())
                    return Result.Failure(
                        "La venta no contiene detalles.");

                var libros = new List<(Libro Libro, int Cantidad)>();
                var errores = new List<string>();

                // Recuperar y validar todos los libros
                foreach (var detalle in venta.Detalles)
                {
                    var libro = _unitOfWork.Libros
                        .ObtenerPorId(detalle.LibroId, true);

                    if (libro is null)
                    {
                        errores.Add(
                            $"No existe el libro ID {detalle.LibroId}.");
                        continue;
                    }

                    if (detalle.Cantidad <= 0)
                    {
                        errores.Add(
                            $"Cantidad inválida para el libro {libro.Titulo}.");
                        continue;
                    }

                    if (libro is LibroFisico fisico &&
                        fisico.Stock > int.MaxValue - detalle.Cantidad)
                    {
                        errores.Add(
                            $"No se puede restituir el stock de {libro.Titulo}.");
                        continue;
                    }

                    libros.Add((libro, detalle.Cantidad));
                }

                if (errores.Count > 0)
                    return Result.Failure(errores);

                // Restituir stock (el libro digital no tiene stock, no hace nada)
                foreach (var item in libros)
                {
                    item.Libro.ReponerStock(item.Cantidad);
                }

                // Cambiar estado
                venta.Anular();

                // Guardar todos los cambios juntos (venta y stock)
                _unitOfWork.Save();

                return Result.Success();
            }
            catch (DbUpdateConcurrencyException)
            {
                return Result.ConcurrencyFailure(
                    "Otro usuario modificó la venta o el stock.\n" +
                    "La grilla se recargará automáticamente");
            }
            catch (DbUpdateException)
            {
                return Result.Failure(
                    "Ocurrió un error al anular la venta.");
            }
            catch (Exception ex)
            {
                return Result.Failure($"Error al intentar anular la venta: {ex.Message}");
            }
        }

        public Result<VentaDetailDto?> ObtenerPorId(int ventaId)
        {
            try
            {
                var venta = _unitOfWork.Ventas.ObtenerPorId(ventaId);
                if (venta == null)
                {
                    return Result<VentaDetailDto?>.Failure($"No se encontró la venta con ID {ventaId}");
                }
                return Result<VentaDetailDto?>.Success(VentaMapper.ToDetailDto(venta));
            }
            catch (Exception ex)
            {
                return Result<VentaDetailDto?>.Failure($"Error al intentar obtener la venta: {ex.Message}");
            }
        }

        public Result<ResultadoPaginacionDto<VentaListDto>> ObtenerPagina(
            int pagina,
            int cantidad,
            string campoOrden,
            bool esAscendente,
            EstadoVenta? filtroEstado = null,
            string? textoBuscar = null)
        {
            try
            {
                Expression<Func<Venta, bool>>? filtro = v =>
                        (!filtroEstado.HasValue || v.Estado == filtroEstado.Value) &&
                        (string.IsNullOrWhiteSpace(textoBuscar) ||
                         v.Cliente.Apellido.Contains(textoBuscar!) ||
                         v.Cliente.Nombre.Contains(textoBuscar!));


                //acomodo que carlos arma el orden pero al no pasarlo al repo, asique la grilla siempre sale ordenada por fecha. Acá sí se usa el orden elegido.
                Func<IQueryable<Venta>, IOrderedQueryable<Venta>>? ordenarPor = campoOrden switch
                {
                    "ImporteTotal" => q => esAscendente ? q.OrderBy(v => v.ImporteTotal) : q.OrderByDescending(v => v.ImporteTotal),
                    "Cliente" => q => esAscendente ? q.OrderBy(v => v.Cliente.Apellido) : q.OrderByDescending(v => v.Cliente.Apellido),
                    _ => q => esAscendente
                        ? q.OrderBy(v => v.Fecha).ThenBy(v => v.VentaId)
                        : q.OrderByDescending(v => v.Fecha).ThenByDescending(v => v.VentaId),
                };

                Func<IQueryable<Venta>, IQueryable<Venta>>? incluir = q => q
                    .Include(v => v.Cliente)
                    .Include(v => v.Detalles);

                var resultado = _unitOfWork.Ventas.ObtenerPagina(pagina, cantidad, ordenarPor, filtro, incluir);
                var listaDto = resultado.lista.Select(v => VentaMapper.ToListDto(v)).ToList();

                var resultadoPaginado = new ResultadoPaginacionDto<VentaListDto>()
                {
                    Items = listaDto,
                    CantidadRegistros = resultado.totalRegistros,
                    CantidadPorPagina = cantidad,
                    PaginaActual = pagina
                };
                return Result<ResultadoPaginacionDto<VentaListDto>>.Success(resultadoPaginado);
            }
            catch (Exception ex)
            {
                return Result<ResultadoPaginacionDto<VentaListDto>>.Failure($"Error al intentar paginar: {ex.Message}");
            }
        }

        public Result<int> ObtenerPaginaRegistro(int seleccionadoId, int cantidadPorPagina,
            EstadoVenta? filtroEstado = null, string? textoBuscar = null)
        {
            try
            {
                Expression<Func<Venta, bool>>? filtro = v =>
                        (!filtroEstado.HasValue || v.Estado == filtroEstado.Value) &&
                        (string.IsNullOrWhiteSpace(textoBuscar) ||
                         v.Cliente.Apellido.Contains(textoBuscar!) ||
                         v.Cliente.Nombre.Contains(textoBuscar!));

                var posicion = _unitOfWork.Ventas.ObtenerPosicionRegistro(seleccionadoId, filtro);
                var pagina = (int)Math.Ceiling((double)posicion / cantidadPorPagina);
                return Result<int>.Success(pagina);
            }
            catch (Exception ex)
            {
                return Result<int>.Failure($"Error al intentar obtener la página: {ex.Message}");
            }
        }
    }
}
