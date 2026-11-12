using TpLibreria.Datos;
using TpLibreria.Entidades;
using TpLibreria.Servicios.Common;
using TpLibreria.Servicios.DTOs.Editorial;
using TpLibreria.Servicios.Interfaces;
using TpLibreria.Servicios.Mapeadores;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace TpLibreria.Servicios.Servicios
{
    public class EditorialServicio : IEditorialServicio
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<EditorialCreateDto> _createValidator;
        private readonly IValidator<EditorialUpdateDto> _updateValidator;

        public EditorialServicio(
            IUnitOfWork unitOfWork,
            IValidator<EditorialCreateDto> createValidator,
            IValidator<EditorialUpdateDto> updateValidator)
        {
            _unitOfWork = unitOfWork;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
        }

        public Result<int> Agregar(EditorialCreateDto editorialDto)
        {
            try
            {
                // 1. Validar el DTO antes de mapear
                var validationResult = _createValidator.Validate(editorialDto);
                if (!validationResult.IsValid)
                {
                    return Result<int>.Failure(validationResult.Errors.Select(e => e.ErrorMessage).ToList());
                }

                // 2. Mapear a la entidad de dominio
                var editorial = EditorialMapper.ToEntidad(editorialDto);

                // 3. Regla de negocio de duplicados
                if (_unitOfWork.Editoriales.Existe(editorial))
                {
                    return Result<int>.Failure($"Ya existe una editorial con el nombre {editorial.Nombre}");
                }

                _unitOfWork.Editoriales.Agregar(editorial);
                _unitOfWork.Save();

                return Result<int>.Success(editorial.EditorialId);
            }
            catch (Exception ex)
            {
                return Result<int>.Failure($"Error al intentar agregar una editorial: {ex.Message}");
            }
        }

        public Result Editar(EditorialUpdateDto dto)
        {
            try
            {
                var validationResult = _updateValidator.Validate(dto);
                if (!validationResult.IsValid)
                {
                    return Result.Failure(validationResult.Errors.Select(e => e.ErrorMessage).ToList());
                }

                var entidad = EditorialMapper.ToEntidad(dto);

                if (_unitOfWork.Editoriales.Existe(entidad))
                {
                    return Result.Failure($"Ya existe una editorial con el nombre {entidad.Nombre}");
                }

                _unitOfWork.Editoriales.Editar(entidad, entidad.EditorialId, dto.RowVersion);
                _unitOfWork.Save();

                return Result.Success();
            }
            catch (DbUpdateConcurrencyException)
            {
                return Result.ConcurrencyFailure("Otro usuario modificó el registro.\nLa grilla se recargará automáticamente");
            }
            catch (KeyNotFoundException)
            {
                return Result.Failure($"Editorial con ID {dto.EditorialId} no encontrada");
            }
            catch (Exception ex)
            {
                return Result.Failure($"Error al intentar editar una editorial: {ex.Message}");
            }
        }

        public Result Borrar(EditorialDeleteDto editorialDto)
        {
            try
            {
                var entidad = _unitOfWork.Editoriales.ObtenerPorId(editorialDto.EditorialId);
                if (entidad is null)
                {
                    return Result.Failure($"Editorial con ID: {editorialDto.EditorialId} no encontrada");
                }
                if (_unitOfWork.Editoriales.TieneRegistrosRelacionados(entidad.EditorialId))
                {
                    return Result.Failure($"No se puede eliminar la editorial {entidad.Nombre} porque tiene libros asociados");
                }

                _unitOfWork.Editoriales.Borrar(editorialDto.EditorialId, editorialDto.RowVersion);
                _unitOfWork.Save();
                return Result.Success();
            }
            catch (DbUpdateConcurrencyException)
            {
                return Result.ConcurrencyFailure("Otro usuario modificó el registro\nLa grilla se recargará automáticamente");
            }
            catch (KeyNotFoundException)
            {
                return Result.Failure($"Editorial con ID: {editorialDto.EditorialId} no encontrada");
            }
            catch (Exception ex)
            {
                return Result.Failure($"Error al intentar borrar una editorial: {ex.Message}");
            }
        }

        public Result<List<EditorialListDto>> ObtenerTodos()
        {
            try
            {
                var lista = _unitOfWork.Editoriales.ObtenerTodos();
                var listaDto = lista.Select(x => EditorialMapper.ToListDto(x)).ToList();
                return Result<List<EditorialListDto>>.Success(listaDto);
            }
            catch (Exception ex)
            {
                return Result<List<EditorialListDto>>.Failure(ex.Message);
            }
        }

        public Result<EditorialListDto> ObtenerPorId(int id)
        {
            try
            {
                var editorial = _unitOfWork.Editoriales.ObtenerPorId(id);
                if (editorial != null)
                {
                    var editorialDto = EditorialMapper.ToListDto(editorial);
                    return Result<EditorialListDto>.Success(editorialDto);
                }

                return Result<EditorialListDto>.Failure("Editorial no encontrada!!!");
            }
            catch (Exception ex)
            {
                return Result<EditorialListDto>.Failure(ex.Message);
            }
        }

        public Result<EditorialUpdateDto> ObtenerParaEditar(int id)
        {
            var editorial = _unitOfWork.Editoriales.ObtenerPorId(id);
            if (editorial != null)
            {
                var editorialDto = EditorialMapper.ToUpdateDto(editorial);
                return Result<EditorialUpdateDto>.Success(editorialDto);
            }

            return Result<EditorialUpdateDto>.Failure("Editorial no encontrada!!!");
        }

        public Result<EditorialDeleteDto> ObtenerParaBorrar(int id)
        {
            var editorial = _unitOfWork.Editoriales.ObtenerPorId(id);
            if (editorial != null)
            {
                var editorialDto = EditorialMapper.ToDeleteDto(editorial);
                return Result<EditorialDeleteDto>.Success(editorialDto);
            }

            return Result<EditorialDeleteDto>.Failure("Error al intentar obtener una editorial");
        }

        public Result<List<EditorialListDto>> FiltrarPorActivo(bool activo)
        {
            try
            {
                var query = _unitOfWork.Editoriales.Query();
                var lista = query.Where(x => x.Activo == activo);
                var listaDto = lista.Select(x => EditorialMapper.ToListDto(x)).ToList();
                return Result<List<EditorialListDto>>.Success(listaDto);
            }
            catch (Exception ex)
            {
                return Result<List<EditorialListDto>>.Failure($"Error al intentar filtrar las editoriales: {ex.Message}");
            }
        }

        public Result<ResultadoPaginacionDto<EditorialListDto>> ObtenerPagina(
            int pagina,
            int cantidad,
            string campoOrden,
            bool esAscendente,
            bool? filtroActivo = null, string? textoBuscar = null)
        {
            try
            {
                Expression<Func<Editorial, bool>>? filtro = x =>
                        (!filtroActivo.HasValue || x.Activo == filtroActivo.Value) &&
                        (string.IsNullOrWhiteSpace(textoBuscar) || x.Nombre.Contains(textoBuscar!) || x.PaisOrigen.Contains(textoBuscar!));

                Func<IQueryable<Editorial>, IOrderedQueryable<Editorial>>? ordenarPor = campoOrden switch
                {
                    "EditorialId" => q => esAscendente ? q.OrderBy(x => x.EditorialId) : q.OrderByDescending(x => x.EditorialId),
                    _ => q => esAscendente ? q.OrderBy(x => x.Nombre) : q.OrderByDescending(x => x.Nombre),
                };

                var resultado = _unitOfWork.Editoriales.ObtenerPagina(pagina, cantidad, ordenarPor, filtro);
                var listaDto = resultado.lista.Select(x => EditorialMapper.ToListDto(x)).ToList();

                var resultadoPaginado = new ResultadoPaginacionDto<EditorialListDto>()
                {
                    Items = listaDto,
                    CantidadRegistros = resultado.totalRegistros,
                    CantidadPorPagina = cantidad,
                    PaginaActual = pagina
                };

                return Result<ResultadoPaginacionDto<EditorialListDto>>.Success(resultadoPaginado);
            }
            catch (Exception ex)
            {
                return Result<ResultadoPaginacionDto<EditorialListDto>>.Failure($"Error al intentar paginar: {ex.Message}");
            }
        }

        public Result<int> ObtenerPaginaRegistro(int seleccionadoId, int cantidadPorPagina,
            bool? filtroActivo = null, string? textoBuscar = null)
        {
            try
            {
                Expression<Func<Editorial, bool>>? filtro = x =>
                        (!filtroActivo.HasValue || x.Activo == filtroActivo.Value) &&
                        (string.IsNullOrWhiteSpace(textoBuscar) || x.Nombre.Contains(textoBuscar!) || x.PaisOrigen.Contains(textoBuscar!));

                var posicion = _unitOfWork.Editoriales.ObtenerPosicionRegistro(seleccionadoId, filtro);
                var pagina = (int)Math.Ceiling((double)posicion / cantidadPorPagina);
                return Result<int>.Success(pagina);
            }
            catch (Exception ex)
            {
                return Result<int>.Failure($"Error al intentar obtener la página: {ex.Message}");
            }
        }

        public Result<List<EditorialComboDto>> ObtenerDatosCombo(bool soloActivas = true, int? incluirId = null)
        {
            try
            {
                var query = _unitOfWork.Editoriales.Query();
                if (soloActivas)
                {
                    query = query.Where(x => x.Activo || (incluirId.HasValue && x.EditorialId == incluirId.Value));
                }
                var lista = query
                    .OrderBy(x => x.Nombre)
                    .ToList()
                    .Select(x => EditorialMapper.ToComboDto(x))
                    .ToList();
                return Result<List<EditorialComboDto>>.Success(lista);
            }
            catch (Exception ex)
            {
                return Result<List<EditorialComboDto>>.Failure($"Error al intentar obtener la lista de las editoriales: {ex.Message}");
            }
        }
    }
}
