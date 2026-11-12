using TpLibreria.Datos;
using TpLibreria.Entidades;
using TpLibreria.Servicios.Common;
using TpLibreria.Servicios.DTOs.Autor;
using TpLibreria.Servicios.Interfaces;
using TpLibreria.Servicios.Mapeadores;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace TpLibreria.Servicios.Servicios
{
    public class AutorServicio : IAutorServicio
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<AutorCreateDto> _createValidator;
        private readonly IValidator<AutorUpdateDto> _updateValidator;

        public AutorServicio(
            IUnitOfWork unitOfWork,
            IValidator<AutorCreateDto> createValidator,
            IValidator<AutorUpdateDto> updateValidator)
        {
            _unitOfWork = unitOfWork;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
        }

        public Result<int> Agregar(AutorCreateDto autorDto)
        {
            try
            {
                // 1. Validar el DTO antes de mapear
                var validationResult = _createValidator.Validate(autorDto);
                if (!validationResult.IsValid)
                {
                    return Result<int>.Failure(validationResult.Errors.Select(e => e.ErrorMessage).ToList());
                }

                // 2. Mapear a la entidad de dominio
                var autor = AutorMapper.ToEntidad(autorDto);

                // 3. Regla de negocio de duplicados
                if (_unitOfWork.Autores.Existe(autor))
                {
                    return Result<int>.Failure($"Ya existe un autor llamado {autor.Nombre} {autor.Apellido} con la misma fecha de nacimiento");
                }

                _unitOfWork.Autores.Agregar(autor);
                _unitOfWork.Save();

                return Result<int>.Success(autor.AutorId);
            }
            catch (Exception ex)
            {
                return Result<int>.Failure($"Error al intentar agregar un autor: {ex.Message}");
            }
        }

        public Result Editar(AutorUpdateDto dto)
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
                var entidad = AutorMapper.ToEntidad(dto);

                // 3. Regla de negocio de duplicados
                if (_unitOfWork.Autores.Existe(entidad))
                {
                    return Result.Failure($"Ya existe un autor llamado {entidad.Nombre} {entidad.Apellido} con la misma fecha de nacimiento");
                }

                _unitOfWork.Autores.Editar(entidad, entidad.AutorId, dto.RowVersion);
                _unitOfWork.Save();

                return Result.Success();
            }
            catch (DbUpdateConcurrencyException)
            {
                return Result.ConcurrencyFailure("Otro usuario modificó el registro.\nLa grilla se recargará automáticamente");
            }
            catch (KeyNotFoundException)
            {
                return Result.Failure($"Autor con ID {dto.AutorId} no encontrado");
            }
            catch (Exception ex)
            {
                return Result.Failure($"Error al intentar editar un autor: {ex.Message}");
            }
        }

        public Result Borrar(AutorDeleteDto autorDto)
        {
            try
            {
                var entidad = _unitOfWork.Autores.ObtenerPorId(autorDto.AutorId);
                if (entidad is null)
                {
                    return Result.Failure($"Autor con ID: {autorDto.AutorId} no encontrado");
                }
                //no se elimina si está relacionado con otros registros
                if (_unitOfWork.Autores.TieneRegistrosRelacionados(entidad.AutorId))
                {
                    return Result.Failure($"No se puede eliminar al autor {entidad.NombreCompleto} porque tiene libros asociados");
                }

                _unitOfWork.Autores.Borrar(autorDto.AutorId, autorDto.RowVersion);
                _unitOfWork.Save();
                return Result.Success();
            }
            catch (DbUpdateConcurrencyException)
            {
                return Result.ConcurrencyFailure("Otro usuario modificó el registro\nLa grilla se recargará automáticamente");
            }
            catch (KeyNotFoundException)
            {
                return Result.Failure($"Autor con ID: {autorDto.AutorId} no encontrado");
            }
            catch (Exception ex)
            {
                return Result.Failure($"Error al intentar borrar un autor: {ex.Message}");
            }
        }

        public Result<List<AutorListDto>> ObtenerTodos()
        {
            try
            {
                var lista = _unitOfWork.Autores.ObtenerTodos();
                var listaDto = lista.Select(x => AutorMapper.ToListDto(x)).ToList();
                return Result<List<AutorListDto>>.Success(listaDto);
            }
            catch (Exception ex)
            {
                return Result<List<AutorListDto>>.Failure(ex.Message);
            }
        }

        public Result<AutorListDto> ObtenerPorId(int id)
        {
            try
            {
                var autor = _unitOfWork.Autores.ObtenerPorId(id);
                if (autor != null)
                {
                    var autorDto = AutorMapper.ToListDto(autor);
                    return Result<AutorListDto>.Success(autorDto);
                }

                return Result<AutorListDto>.Failure("Autor no encontrado!!!");
            }
            catch (Exception ex)
            {
                return Result<AutorListDto>.Failure(ex.Message);
            }
        }

        public Result<AutorUpdateDto> ObtenerParaEditar(int id)
        {
            var autor = _unitOfWork.Autores.ObtenerPorId(id);
            if (autor != null)
            {
                var autorDto = AutorMapper.ToUpdateDto(autor);
                return Result<AutorUpdateDto>.Success(autorDto);
            }

            return Result<AutorUpdateDto>.Failure("Autor no encontrado!!!");
        }

        public Result<AutorDeleteDto> ObtenerParaBorrar(int id)
        {
            var autor = _unitOfWork.Autores.ObtenerPorId(id);
            if (autor != null)
            {
                var autorDto = AutorMapper.ToDeleteDto(autor);
                return Result<AutorDeleteDto>.Success(autorDto);
            }

            return Result<AutorDeleteDto>.Failure("Error al intentar obtener un autor");
        }

        public Result<ResultadoPaginacionDto<AutorListDto>> ObtenerPagina(
            int pagina,
            int cantidad,
            string campoOrden,
            bool esAscendente,
            string? textoBuscar = null)
        {
            try
            {
                Expression<Func<Autor, bool>>? filtro = x =>
                        (string.IsNullOrWhiteSpace(textoBuscar) || x.Nombre.Contains(textoBuscar!) || x.Apellido.Contains(textoBuscar!) || x.Nacionalidad.Contains(textoBuscar!));

                Func<IQueryable<Autor>, IOrderedQueryable<Autor>>? ordenarPor = campoOrden switch
                {
                    "AutorId" => q => esAscendente ? q.OrderBy(x => x.AutorId) : q.OrderByDescending(x => x.AutorId),
                    "Nombre" => q => esAscendente ? q.OrderBy(x => x.Nombre) : q.OrderByDescending(x => x.Nombre),
                    _ => q => esAscendente
                        ? q.OrderBy(x => x.Apellido).ThenBy(x => x.Nombre)
                        : q.OrderByDescending(x => x.Apellido).ThenByDescending(x => x.Nombre),
                };

                var resultado = _unitOfWork.Autores.ObtenerPagina(pagina, cantidad, ordenarPor, filtro);
                var listaDto = resultado.lista.Select(x => AutorMapper.ToListDto(x)).ToList();

                var resultadoPaginado = new ResultadoPaginacionDto<AutorListDto>()
                {
                    Items = listaDto,
                    CantidadRegistros = resultado.totalRegistros,
                    CantidadPorPagina = cantidad,
                    PaginaActual = pagina
                };

                return Result<ResultadoPaginacionDto<AutorListDto>>.Success(resultadoPaginado);
            }
            catch (Exception ex)
            {
                return Result<ResultadoPaginacionDto<AutorListDto>>.Failure($"Error al intentar paginar: {ex.Message}");
            }
        }

        public Result<int> ObtenerPaginaRegistro(int seleccionadoId, int cantidadPorPagina,
            string? textoBuscar = null)
        {
            try
            {
                Expression<Func<Autor, bool>>? filtro = x =>
                        (string.IsNullOrWhiteSpace(textoBuscar) || x.Nombre.Contains(textoBuscar!) || x.Apellido.Contains(textoBuscar!) || x.Nacionalidad.Contains(textoBuscar!));

                var posicion = _unitOfWork.Autores.ObtenerPosicionRegistro(seleccionadoId, filtro);
                var pagina = (int)Math.Ceiling((double)posicion / cantidadPorPagina);
                return Result<int>.Success(pagina);
            }
            catch (Exception ex)
            {
                return Result<int>.Failure($"Error al intentar obtener la página: {ex.Message}");
            }
        }

        public Result<List<AutorComboDto>> ObtenerDatosCombo()
        {
            try
            {
                var query = _unitOfWork.Autores.Query();
                var lista = query
                    .OrderBy(x => x.Apellido).ThenBy(x => x.Nombre)
                    .ToList()
                    .Select(x => AutorMapper.ToComboDto(x))
                    .ToList();
                return Result<List<AutorComboDto>>.Success(lista);
            }
            catch (Exception ex)
            {
                return Result<List<AutorComboDto>>.Failure($"Error al intentar obtener la lista de los autores: {ex.Message}");
            }
        }

        public Result<List<AutorComboDto>> ObtenerPorIds(List<int> ids)
        {
            try
            {
                var lista = _unitOfWork.Autores.Query()
                    .Where(x => ids.Contains(x.AutorId))
                    .OrderBy(x => x.Apellido).ThenBy(x => x.Nombre)
                    .ToList()
                    .Select(x => AutorMapper.ToComboDto(x))
                    .ToList();
                return Result<List<AutorComboDto>>.Success(lista);
            }
            catch (Exception ex)
            {
                return Result<List<AutorComboDto>>.Failure($"Error al intentar obtener los autores: {ex.Message}");
            }
        }
    }
}
