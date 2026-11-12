using TpLibreria.Datos;
using TpLibreria.Entidades;
using TpLibreria.Entidades.Enums;
using TpLibreria.Servicios.Common;
using TpLibreria.Servicios.DTOs.Cliente;
using TpLibreria.Servicios.Interfaces;
using TpLibreria.Servicios.Mapeadores;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace TpLibreria.Servicios.Servicios
{
    public class ClienteServicio : IClienteServicio
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<ClienteCreateDto> _createValidator;
        private readonly IValidator<ClienteUpdateDto> _updateValidator;

        public ClienteServicio(
            IUnitOfWork unitOfWork,
            IValidator<ClienteCreateDto> createValidator,
            IValidator<ClienteUpdateDto> updateValidator)
        {
            _unitOfWork = unitOfWork;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
        }

        public Result<int> Agregar(ClienteCreateDto clienteDto)
        {
            try
            {
                // 1. Validar el DTO antes de mapear
                var validationResult = _createValidator.Validate(clienteDto);
                if (!validationResult.IsValid)
                {
                    return Result<int>.Failure(validationResult.Errors.Select(e => e.ErrorMessage).ToList());
                }

                // 2. Mapear a la entidad de dominio
                var cliente = ClienteMapper.ToEntidad(clienteDto);

                // 3. Regla de negocio de duplicados
                if (_unitOfWork.Clientes.Existe(cliente))
                {
                    return Result<int>.Failure($"Ya existe un cliente con el email {cliente.Email}");
                }

                _unitOfWork.Clientes.Agregar(cliente);
                _unitOfWork.Save();

                return Result<int>.Success(cliente.ClienteId);
            }
            catch (Exception ex)
            {
                return Result<int>.Failure($"Error al intentar agregar un cliente: {ex.Message}");
            }
        }

        public Result Editar(ClienteUpdateDto dto)
        {
            try
            {
                // 1. Validar el DTO antes de mapear
                var validationResult = _updateValidator.Validate(dto);
                if (!validationResult.IsValid)
                {
                    return Result.Failure(validationResult.Errors.Select(e => e.ErrorMessage).ToList());
                }

                // 2. Mapear a la entidad de dominio
                var entidad = ClienteMapper.ToEntidad(dto);

                // 3. Regla de negocio de duplicados
                if (_unitOfWork.Clientes.Existe(entidad))
                {
                    return Result.Failure($"Ya existe un cliente con el email {entidad.Email}");
                }

                _unitOfWork.Clientes.Editar(entidad, entidad.ClienteId, dto.RowVersion);
                _unitOfWork.Save();

                return Result.Success();
            }
            catch (DbUpdateConcurrencyException)
            {
                return Result.ConcurrencyFailure("Otro usuario modificó el registro.\nLa grilla se recargará automáticamente");
            }
            catch (KeyNotFoundException)
            {
                return Result.Failure($"Cliente con ID {dto.ClienteId} no encontrado");
            }
            catch (Exception ex)
            {
                return Result.Failure($"Error al intentar editar un cliente: {ex.Message}");
            }
        }

        public Result Borrar(ClienteDeleteDto clienteDto)
        {
            try
            {
                var entidad = _unitOfWork.Clientes.ObtenerPorId(clienteDto.ClienteId);
                if (entidad is null)
                {
                    return Result.Failure($"Cliente con ID: {clienteDto.ClienteId} no encontrado");
                }
                if (_unitOfWork.Clientes.TieneRegistrosRelacionados(entidad.ClienteId))
                {
                    return Result.Failure($"No se puede eliminar al cliente {entidad.NombreCompleto} porque tiene ventas registradas");
                }

                _unitOfWork.Clientes.Borrar(clienteDto.ClienteId, clienteDto.RowVersion);
                _unitOfWork.Save();
                return Result.Success();
            }
            catch (DbUpdateConcurrencyException)
            {
                return Result.ConcurrencyFailure("Otro usuario modificó el registro\nLa grilla se recargará automáticamente");
            }
            catch (KeyNotFoundException)
            {
                return Result.Failure($"Cliente con ID: {clienteDto.ClienteId} no encontrado");
            }
            catch (Exception ex)
            {
                return Result.Failure($"Error al intentar borrar un cliente: {ex.Message}");
            }
        }

        public Result<List<ClienteListDto>> ObtenerTodos()
        {
            try
            {
                var lista = _unitOfWork.Clientes.ObtenerTodos();
                var listaDto = lista.Select(x => ClienteMapper.ToListDto(x)).ToList();
                return Result<List<ClienteListDto>>.Success(listaDto);
            }
            catch (Exception ex)
            {
                return Result<List<ClienteListDto>>.Failure(ex.Message);
            }
        }

        public Result<ClienteListDto> ObtenerPorId(int id)
        {
            try
            {
                var cliente = _unitOfWork.Clientes.ObtenerPorId(id);
                if (cliente != null)
                {
                    var clienteDto = ClienteMapper.ToListDto(cliente);
                    return Result<ClienteListDto>.Success(clienteDto);
                }

                return Result<ClienteListDto>.Failure("Cliente no encontrado!!!");
            }
            catch (Exception ex)
            {
                return Result<ClienteListDto>.Failure(ex.Message);
            }
        }

        public Result<ClienteUpdateDto> ObtenerParaEditar(int id)
        {
            var cliente = _unitOfWork.Clientes.ObtenerPorId(id);
            if (cliente != null)
            {
                var clienteDto = ClienteMapper.ToUpdateDto(cliente);
                return Result<ClienteUpdateDto>.Success(clienteDto);
            }

            return Result<ClienteUpdateDto>.Failure("Cliente no encontrado!!!");
        }

        public Result<ClienteDeleteDto> ObtenerParaBorrar(int id)
        {
            var cliente = _unitOfWork.Clientes.ObtenerPorId(id);
            if (cliente != null)
            {
                var clienteDto = ClienteMapper.ToDeleteDto(cliente);
                return Result<ClienteDeleteDto>.Success(clienteDto);
            }

            return Result<ClienteDeleteDto>.Failure("Error al intentar obtener un cliente");
        }

        public Result<ResultadoPaginacionDto<ClienteListDto>> ObtenerPagina(
            int pagina,
            int cantidad,
            string campoOrden,
            bool esAscendente,
            string? textoBuscar = null)
        {
            try
            {
                Expression<Func<Cliente, bool>>? filtro = x =>
                        (string.IsNullOrWhiteSpace(textoBuscar) || x.Nombre.Contains(textoBuscar!) || x.Apellido.Contains(textoBuscar!) || x.Email.Contains(textoBuscar!) || (x.Telefono != null && x.Telefono.Contains(textoBuscar!)));

                Func<IQueryable<Cliente>, IOrderedQueryable<Cliente>>? ordenarPor = campoOrden switch
                {
                    "ClienteId" => q => esAscendente ? q.OrderBy(x => x.ClienteId) : q.OrderByDescending(x => x.ClienteId),
                    "Nombre" => q => esAscendente ? q.OrderBy(x => x.Nombre) : q.OrderByDescending(x => x.Nombre),
                    _ => q => esAscendente
                        ? q.OrderBy(x => x.Apellido).ThenBy(x => x.Nombre)
                        : q.OrderByDescending(x => x.Apellido).ThenByDescending(x => x.Nombre),
                };

                var resultado = _unitOfWork.Clientes.ObtenerPagina(pagina, cantidad, ordenarPor, filtro);
                var listaDto = resultado.lista.Select(x => ClienteMapper.ToListDto(x)).ToList();

                var resultadoPaginado = new ResultadoPaginacionDto<ClienteListDto>()
                {
                    Items = listaDto,
                    CantidadRegistros = resultado.totalRegistros,
                    CantidadPorPagina = cantidad,
                    PaginaActual = pagina
                };

                return Result<ResultadoPaginacionDto<ClienteListDto>>.Success(resultadoPaginado);
            }
            catch (Exception ex)
            {
                return Result<ResultadoPaginacionDto<ClienteListDto>>.Failure($"Error al intentar paginar: {ex.Message}");
            }
        }

        public Result<int> ObtenerPaginaRegistro(int seleccionadoId, int cantidadPorPagina,
            string? textoBuscar = null)
        {
            try
            {
                Expression<Func<Cliente, bool>>? filtro = x =>
                        (string.IsNullOrWhiteSpace(textoBuscar) || x.Nombre.Contains(textoBuscar!) || x.Apellido.Contains(textoBuscar!) || x.Email.Contains(textoBuscar!) || (x.Telefono != null && x.Telefono.Contains(textoBuscar!)));

                var posicion = _unitOfWork.Clientes.ObtenerPosicionRegistro(seleccionadoId, filtro);
                var pagina = (int)Math.Ceiling((double)posicion / cantidadPorPagina);
                return Result<int>.Success(pagina);
            }
            catch (Exception ex)
            {
                return Result<int>.Failure($"Error al intentar obtener la página: {ex.Message}");
            }
        }

        // Igual que el profe: el servicio agrega la primera fila del combo ("Seleccione" o "Todos")
        public Result<List<ClienteComboDto>> ObtenerDatosCombo(ClienteDefault defaultCliente)
        {
            try
            {
                var query = _unitOfWork.Clientes.Query();
                var lista = query
                    .OrderBy(x => x.Apellido).ThenBy(x => x.Nombre)
                    .ToList()
                    .Select(x => ClienteMapper.ToComboDto(x))
                    .ToList();
                var clienteDefault = new ClienteComboDto
                {
                    ClienteId = 0,
                    NombreCompleto = defaultCliente == ClienteDefault.Todos ? "Todos" : "Seleccione"
                };
                lista.Insert(0, clienteDefault);
                return Result<List<ClienteComboDto>>.Success(lista);
            }
            catch (Exception ex)
            {
                return Result<List<ClienteComboDto>>.Failure($"Error al intentar obtener la lista de los clientes: {ex.Message}");
            }
        }
    }
}
