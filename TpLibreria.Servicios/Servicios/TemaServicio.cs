using TpLibreria.Datos;
using TpLibreria.Entidades;
using TpLibreria.Servicios.Common;
using TpLibreria.Servicios.DTOs.Tema;
using TpLibreria.Servicios.Interfaces;
using TpLibreria.Servicios.Mapeadores;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace TpLibreria.Servicios.Servicios
{
    public class TemaServicio : ITemaServicio
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<TemaCreateDto> _createValidator;
        private readonly IValidator<TemaUpdateDto> _updateValidator;

        public TemaServicio(
            IUnitOfWork unitOfWork,
            IValidator<TemaCreateDto> createValidator,
            IValidator<TemaUpdateDto> updateValidator)
        {
            _unitOfWork = unitOfWork;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
        }

        public Result<int> Agregar(TemaCreateDto temaDto)
        {
            try
            {
                // 1. Validar el DTO antes de mapear
                var validationResult = _createValidator.Validate(temaDto);
                if (!validationResult.IsValid)
                {
                    return Result<int>.Failure(validationResult.Errors.Select(e => e.ErrorMessage).ToList());
                }

                // 2. Mapear a la entidad de dominio
                var tema = TemaMapper.ToEntidad(temaDto);

                // 3. Regla de negocio de duplicados
                if (_unitOfWork.Temas.Existe(tema))
                {
                    return Result<int>.Failure($"Ya existe un tema con el nombre {tema.Nombre}");
                }

                _unitOfWork.Temas.Agregar(tema);
                _unitOfWork.Save();

                return Result<int>.Success(tema.TemaId);
            }
            catch (Exception ex)
            {
                return Result<int>.Failure($"Error al intentar agregar un tema: {ex.Message}");
            }
        }

        public Result Editar(TemaUpdateDto dto)
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
                var entidad = TemaMapper.ToEntidad(dto);

                // 3. Regla de negocio de duplicados
                if (_unitOfWork.Temas.Existe(entidad))
                {
                    return Result.Failure($"Ya existe un tema con el nombre {entidad.Nombre}");
                }

                _unitOfWork.Temas.Editar(entidad, entidad.TemaId, dto.RowVersion);
                _unitOfWork.Save();

                return Result.Success();
            }
            catch (DbUpdateConcurrencyException)
            {
                return Result.ConcurrencyFailure("Otro usuario modificó el registro.\nLa grilla se recargará automáticamente");
            }
            catch (KeyNotFoundException)
            {
                return Result.Failure($"Tema con ID {dto.TemaId} no encontrado");
            }
            catch (Exception ex)
            {
                return Result.Failure($"Error al intentar editar un tema: {ex.Message}");
            }
        }

        public Result Borrar(TemaDeleteDto temaDto)
        {
            try
            {
                var entidad = _unitOfWork.Temas.ObtenerPorId(temaDto.TemaId);
                if (entidad is null)
                {
                    return Result.Failure($"Tema con ID: {temaDto.TemaId} no encontrado");
                }
                if (_unitOfWork.Temas.TieneRegistrosRelacionados(entidad.TemaId))
                {
                    return Result.Failure($"No se puede eliminar el tema {entidad.Nombre} porque tiene libros asociados");
                }

                _unitOfWork.Temas.Borrar(temaDto.TemaId, temaDto.RowVersion);
                _unitOfWork.Save();
                return Result.Success();
            }
            catch (DbUpdateConcurrencyException)
            {
                return Result.ConcurrencyFailure("Otro usuario modificó el registro\nLa grilla se recargará automáticamente");
            }
            catch (KeyNotFoundException)
            {
                return Result.Failure($"Tema con ID: {temaDto.TemaId} no encontrado");
            }
            catch (Exception ex)
            {
                return Result.Failure($"Error al intentar borrar un tema: {ex.Message}");
            }
        }

        public Result<List<TemaListDto>> ObtenerTodos()
        {
            try
            {
                var lista = _unitOfWork.Temas.ObtenerTodos();
                var listaDto = lista.Select(x => TemaMapper.ToListDto(x)).ToList();
                return Result<List<TemaListDto>>.Success(listaDto);
            }
            catch (Exception ex)
            {
                return Result<List<TemaListDto>>.Failure(ex.Message);
            }
        }

        public Result<TemaListDto> ObtenerPorId(int id)
        {
            try
            {
                var tema = _unitOfWork.Temas.ObtenerPorId(id);
                if (tema != null)
                {
                    var temaDto = TemaMapper.ToListDto(tema);
                    return Result<TemaListDto>.Success(temaDto);
                }

                return Result<TemaListDto>.Failure("Tema no encontrado!!!");
            }
            catch (Exception ex)
            {
                return Result<TemaListDto>.Failure(ex.Message);
            }
        }

        public Result<TemaUpdateDto> ObtenerParaEditar(int id)
        {
            var tema = _unitOfWork.Temas.ObtenerPorId(id);
            if (tema != null)
            {
                var temaDto = TemaMapper.ToUpdateDto(tema);
                return Result<TemaUpdateDto>.Success(temaDto);
            }

            return Result<TemaUpdateDto>.Failure("Tema no encontrado!!!");
        }

        public Result<TemaDeleteDto> ObtenerParaBorrar(int id)
        {
            var tema = _unitOfWork.Temas.ObtenerPorId(id);
            if (tema != null)
            {
                var temaDto = TemaMapper.ToDeleteDto(tema);
                return Result<TemaDeleteDto>.Success(temaDto);
            }

            return Result<TemaDeleteDto>.Failure("Error al intentar obtener un tema");
        }

        public Result<ResultadoPaginacionDto<TemaListDto>> ObtenerPagina(
            int pagina,
            int cantidad,
            string campoOrden,
            bool esAscendente,
            string? textoBuscar = null)
        {
            try
            {
                Expression<Func<Tema, bool>>? filtro = x =>
                        (string.IsNullOrWhiteSpace(textoBuscar) || x.Nombre.Contains(textoBuscar!) || (x.Descripcion != null && x.Descripcion.Contains(textoBuscar!)));

                Func<IQueryable<Tema>, IOrderedQueryable<Tema>>? ordenarPor = campoOrden switch
                {
                    "TemaId" => q => esAscendente ? q.OrderBy(x => x.TemaId) : q.OrderByDescending(x => x.TemaId),
                    _ => q => esAscendente ? q.OrderBy(x => x.Nombre) : q.OrderByDescending(x => x.Nombre),
                };

                var resultado = _unitOfWork.Temas.ObtenerPagina(pagina, cantidad, ordenarPor, filtro);
                var listaDto = resultado.lista.Select(x => TemaMapper.ToListDto(x)).ToList();

                var resultadoPaginado = new ResultadoPaginacionDto<TemaListDto>()
                {
                    Items = listaDto,
                    CantidadRegistros = resultado.totalRegistros,
                    CantidadPorPagina = cantidad,
                    PaginaActual = pagina
                };

                return Result<ResultadoPaginacionDto<TemaListDto>>.Success(resultadoPaginado);
            }
            catch (Exception ex)
            {
                return Result<ResultadoPaginacionDto<TemaListDto>>.Failure($"Error al intentar paginar: {ex.Message}");
            }
        }

        public Result<int> ObtenerPaginaRegistro(int seleccionadoId, int cantidadPorPagina,
            string? textoBuscar = null)
        {
            try
            {
                Expression<Func<Tema, bool>>? filtro = x =>
                        (string.IsNullOrWhiteSpace(textoBuscar) || x.Nombre.Contains(textoBuscar!) || (x.Descripcion != null && x.Descripcion.Contains(textoBuscar!)));

                var posicion = _unitOfWork.Temas.ObtenerPosicionRegistro(seleccionadoId, filtro);
                var pagina = (int)Math.Ceiling((double)posicion / cantidadPorPagina);
                return Result<int>.Success(pagina);
            }
            catch (Exception ex)
            {
                return Result<int>.Failure($"Error al intentar obtener la página: {ex.Message}");
            }
        }

        public Result<List<TemaComboDto>> ObtenerDatosCombo()
        {
            try
            {
                var query = _unitOfWork.Temas.Query();
                var lista = query
                    .OrderBy(x => x.Nombre)
                    .ToList()
                    .Select(x => TemaMapper.ToComboDto(x))
                    .ToList();
                return Result<List<TemaComboDto>>.Success(lista);
            }
            catch (Exception ex)
            {
                return Result<List<TemaComboDto>>.Failure($"Error al intentar obtener la lista de los temas: {ex.Message}");
            }
        }

        public Result<List<TemaComboDto>> ObtenerPorIds(List<int> ids)
        {
            try
            {
                var lista = _unitOfWork.Temas.Query()
                    .Where(x => ids.Contains(x.TemaId))
                    .OrderBy(x => x.Nombre)
                    .ToList()
                    .Select(x => TemaMapper.ToComboDto(x))
                    .ToList();
                return Result<List<TemaComboDto>>.Success(lista);
            }
            catch (Exception ex)
            {
                return Result<List<TemaComboDto>>.Failure($"Error al intentar obtener los temas: {ex.Message}");
            }
        }
    }
}
