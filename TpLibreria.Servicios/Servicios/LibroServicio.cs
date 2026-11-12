using TpLibreria.Datos;
using TpLibreria.Entidades;
using TpLibreria.Servicios.Common;
using TpLibreria.Servicios.DTOs.Libro;
using TpLibreria.Servicios.Interfaces;
using TpLibreria.Servicios.Mapeadores;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace TpLibreria.Servicios.Servicios
{
    public class LibroServicio : ILibroServicio
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<LibroCreateDto> _createValidator;
        private readonly IValidator<LibroUpdateDto> _updateValidator;

        public LibroServicio(
            IUnitOfWork unitOfWork,
            IValidator<LibroCreateDto> createValidator,
            IValidator<LibroUpdateDto> updateValidator)
        {
            _unitOfWork = unitOfWork;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
        }

        public Result<int> Agregar(LibroCreateDto libroDto)
        {
            try
            {
                // 1. Validar el DTO antes de mapear
                var validationResult = _createValidator.Validate(libroDto);
                if (!validationResult.IsValid)
                {
                    return Result<int>.Failure(validationResult.Errors.Select(e => e.ErrorMessage).ToList());
                }

                // 2. Mapear a la entidad (física o digital)
                var libro = LibroMapper.ToEntidad(libroDto);

                // 3. Reglas de negocio
                if (_unitOfWork.Libros.Existe(libro))
                {
                    return Result<int>.Failure("Ya existe un libro con el mismo ISBN o identificador.");
                }
                var editorial = _unitOfWork.Editoriales.ObtenerPorId(libroDto.EditorialId);
                if (editorial is null)
                {
                    return Result<int>.Failure("La editorial seleccionada no existe.");
                }
                if (!editorial.Activo)
                {
                    return Result<int>.Failure($"La editorial {editorial.Nombre} no se encuentra activa.");
                }

                // 4. Asociar autores y temas (uno o más de cada uno)
                var errores = new List<string>();
                AsociarAutores(libro, libroDto.AutoresIds, errores);
                AsociarTemas(libro, libroDto.TemasIds, errores);
                if (errores.Any())
                {
                    return Result<int>.Failure(errores);
                }

                _unitOfWork.Libros.Agregar(libro);
                _unitOfWork.Save();
                return Result<int>.Success(libro.LibroId);
            }
            catch (Exception ex)
            {
                return Result<int>.Failure($"Error al intentar agregar el libro: {ex.Message}");
            }
        }

        public Result Editar(LibroUpdateDto libroDto)
        {
            try
            {
                // 1. Validar el DTO de actualización
                var validationResult = _updateValidator.Validate(libroDto);
                if (!validationResult.IsValid)
                {
                    return Result.Failure(validationResult.Errors.Select(e => e.ErrorMessage).ToList());
                }

                // 2. Obtener la entidad persistida (con sus autores y temas)
                var libro = _unitOfWork.Libros.ObtenerPorId(libroDto.LibroId, true);//uso el true para que sea tracked y pueda hacer el update
                if (libro is null)
                {
                    return Result.Failure("Libro no encontrado.");
                }
                if (libro.Tipo != libroDto.Tipo)
                {
                    return Result.Failure("No se puede cambiar el tipo de un libro (físico o digital).");
                }

                // 3. Si cambia la editorial debe existir y estar activa
                if (libro.EditorialId != libroDto.EditorialId)
                {
                    var editorial = _unitOfWork.Editoriales.ObtenerPorId(libroDto.EditorialId);
                    if (editorial is null)
                    {
                        return Result.Failure("La editorial seleccionada no existe.");
                    }
                    if (!editorial.Activo)
                    {
                        return Result.Failure($"La editorial {editorial.Nombre} no se encuentra activa.");
                    }
                }

                libro.Titulo = libroDto.Titulo;
                libro.Descripcion = libroDto.Descripcion;
                libro.AnioPublicacion = libroDto.AnioPublicacion;
                libro.Precio = libroDto.Precio;
                libro.EditorialId = libroDto.EditorialId;
                libro.Activo = libroDto.Activo;
                if (libro is LibroFisico fisico)
                {
                    fisico.Isbn = libroDto.Isbn!;
                    fisico.Stock = libroDto.Stock;
                }
                else if (libro is LibroDigital digital)
                {
                    digital.Identificador = libroDto.Identificador!;
                    digital.Formato = libroDto.Formato!;
                    digital.TamanoArchivo = libroDto.TamanoArchivo;
                    digital.UrlDescarga = libroDto.UrlDescarga!;
                }

                if (_unitOfWork.Libros.Existe(libro))
                {
                    return Result.Failure("Ya existe otro libro con el mismo ISBN o identificador.");
                }

                var errores = new List<string>();
                SincronizarAutores(libro, libroDto.AutoresIds, errores);
                SincronizarTemas(libro, libroDto.TemasIds, errores);
                if (errores.Any())
                {
                    return Result.Failure(errores);
                }

                _unitOfWork.Libros.Editar(libro, libro.LibroId, libroDto.RowVersion);
                _unitOfWork.Save();
                return Result.Success();
            }
            catch (DbUpdateConcurrencyException)
            {
                return Result.ConcurrencyFailure("Otro usuario modificó el registro.\nLa grilla se recargará automáticamente");
            }
            catch (Exception ex)
            {
                return Result.Failure($"Error al intentar editar el libro: {ex.Message}");
            }
        }

        public Result Borrar(LibroDeleteDto libroDto)
        {
            try
            {
                var libro = _unitOfWork.Libros.ObtenerPorId(libroDto.LibroId);
                if (libro is null)
                {
                    return Result.Failure($"Libro con ID: {libroDto.LibroId} no encontrado");
                }
                // No se puede eliminar un libro que ya fue vendido
                if (_unitOfWork.Libros.TieneRegistrosRelacionados(libro.LibroId))
                {
                    return Result.Failure($"No se puede eliminar el libro \"{libro.Titulo}\" porque figura en ventas");
                }

                _unitOfWork.Libros.Borrar(libroDto.LibroId, libroDto.RowVersion);
                _unitOfWork.Save();
                return Result.Success();
            }
            catch (DbUpdateConcurrencyException)
            {
                return Result.ConcurrencyFailure("Otro usuario modificó el registro\nLa grilla se recargará automáticamente");
            }
            catch (KeyNotFoundException)
            {
                return Result.Failure($"Libro con ID: {libroDto.LibroId} no encontrado");
            }
            catch (Exception ex)
            {
                return Result.Failure($"Error al intentar borrar un libro: {ex.Message}");
            }
        }

        public Result<List<LibroListDto>> ObtenerTodos()
        {
            try
            {
                var lista = _unitOfWork.Libros.ObtenerTodos();
                var listaDto = lista.Select(l => LibroMapper.ToListDto(l)).ToList();
                return Result<List<LibroListDto>>.Success(listaDto);
            }
            catch (Exception ex)
            {
                return Result<List<LibroListDto>>.Failure(ex.Message);
            }
        }

        public Result<LibroListDto> ObtenerPorId(int id)
        {
            try
            {
                var libro = _unitOfWork.Libros.ObtenerPorId(id);
                if (libro is null)
                {
                    return Result<LibroListDto>.Failure("Libro no encontrado.");
                }
                return Result<LibroListDto>.Success(LibroMapper.ToListDto(libro));
            }
            catch (Exception ex)
            {
                return Result<LibroListDto>.Failure(ex.Message);
            }
        }

        public Result<LibroUpdateDto> ObtenerParaEditar(int id)
        {
            try
            {
                var libro = _unitOfWork.Libros.ObtenerPorId(id);
                if (libro is null)
                {
                    return Result<LibroUpdateDto>.Failure("Libro no encontrado.");
                }
                return Result<LibroUpdateDto>.Success(LibroMapper.ToUpdateDto(libro));
            }
            catch (Exception ex)
            {
                return Result<LibroUpdateDto>.Failure(ex.Message);
            }
        }

        public Result<LibroDeleteDto> ObtenerParaBorrar(int id)
        {
            var libro = _unitOfWork.Libros.ObtenerPorId(id);
            if (libro != null)
            {
                return Result<LibroDeleteDto>.Success(LibroMapper.ToDeleteDto(libro));
            }
            return Result<LibroDeleteDto>.Failure("Error al intentar obtener el libro");
        }

        public Result<ResultadoPaginacionDto<LibroListDto>> ObtenerPagina(
            int pagina,
            int cantidad,
            string campoOrden,
            bool esAscendente,
            bool? filtroActivo = null,
            string? textoBuscar = null)
        {
            try
            {
                Expression<Func<Libro, bool>>? filtro = l =>
                        (!filtroActivo.HasValue || l.Activo == filtroActivo.Value) &&
                        (string.IsNullOrWhiteSpace(textoBuscar) ||
                         l.Titulo.Contains(textoBuscar!) ||
                         l.Editorial.Nombre.Contains(textoBuscar!) ||
                         l.Autores.Any(a => a.Apellido.Contains(textoBuscar!) || a.Nombre.Contains(textoBuscar!)));

                Func<IQueryable<Libro>, IOrderedQueryable<Libro>>? ordenarPor = campoOrden switch
                {
                    "LibroId" => q => esAscendente ? q.OrderBy(l => l.LibroId) : q.OrderByDescending(l => l.LibroId),
                    "Precio" => q => esAscendente ? q.OrderBy(l => l.Precio) : q.OrderByDescending(l => l.Precio),
                    _ => q => esAscendente ? q.OrderBy(l => l.Titulo) : q.OrderByDescending(l => l.Titulo),
                };

                Func<IQueryable<Libro>, IQueryable<Libro>>? incluir = q => q
                    .Include(l => l.Editorial)
                    .Include(l => l.Autores);

                var resultado = _unitOfWork.Libros.ObtenerPagina(pagina, cantidad, ordenarPor, filtro, incluir);
                var listaDto = resultado.lista.Select(l => LibroMapper.ToListDto(l)).ToList();

                var resultadoPaginado = new ResultadoPaginacionDto<LibroListDto>()
                {
                    Items = listaDto,
                    CantidadRegistros = resultado.totalRegistros,
                    CantidadPorPagina = cantidad,
                    PaginaActual = pagina
                };
                return Result<ResultadoPaginacionDto<LibroListDto>>.Success(resultadoPaginado);
            }
            catch (Exception ex)
            {
                return Result<ResultadoPaginacionDto<LibroListDto>>.Failure($"Error al intentar paginar: {ex.Message}");
            }
        }

        public Result<int> ObtenerPaginaRegistro(int seleccionadoId, int cantidadPorPagina,
            bool? filtroActivo = null, string? textoBuscar = null)
        {
            try
            {
                Expression<Func<Libro, bool>>? filtro = l =>
                        (!filtroActivo.HasValue || l.Activo == filtroActivo.Value) &&
                        (string.IsNullOrWhiteSpace(textoBuscar) ||
                         l.Titulo.Contains(textoBuscar!) ||
                         l.Editorial.Nombre.Contains(textoBuscar!) ||
                         l.Autores.Any(a => a.Apellido.Contains(textoBuscar!) || a.Nombre.Contains(textoBuscar!)));

                var posicion = _unitOfWork.Libros.ObtenerPosicionRegistro(seleccionadoId, filtro);
                var pagina = (int)Math.Ceiling((double)posicion / cantidadPorPagina);
                return Result<int>.Success(pagina);
            }
            catch (Exception ex)
            {
                return Result<int>.Failure($"Error al intentar obtener la página: {ex.Message}");
            }
        }

        public Result<List<LibroComboDto>> ObtenerDatosCombo()
        {
            try
            {
                var lista = _unitOfWork.Libros.Query()
                    .Include(l => l.Editorial)
                    .Where(l => l.Activo && l.Editorial.Activo)
                    .OrderBy(l => l.Titulo)
                    .ToList()
                    .Select(l => LibroMapper.ToComboDto(l))
                    .ToList();
                return Result<List<LibroComboDto>>.Success(lista);
            }
            catch (Exception ex)
            {
                return Result<List<LibroComboDto>>.Failure($"Error al intentar obtener la lista de libros: {ex.Message}");
            }
        }
        //Aca agrego con ayuda los metodos porq carlos no tiene ningún de estos métodos. Su relación (Caja - Bombón) tiene una clase intermedia con datos y se maneja con Caja.AgregarBombon/EliminarBombon.
        // Libro - Autor y Libro - Tema son muchos a muchos , por eso hace falta asociar los que se eligen y, al editar, quitar los que se sacaron y agregar solo los nuevos.

        private void AsociarAutores(Libro libro, IEnumerable<int> autoresIds, List<string> errores)
        {//este metodo se usa tanto en agregar como en editar, por eso le paso la lista de errores para que la llene si hay alguno
            var ids = autoresIds.Distinct().ToList();//quito duplicados
            var autores = _unitOfWork.Autores.ObtenerPorIds(ids);//obtengo los autores de la base de datos sin usar el tracked, porque no los voy a modificar, solo asociar
            if (autores.Count != ids.Count)
            {
                errores.Add("Alguno de los autores seleccionados no existe.");
                return;
            }
            foreach (var autor in autores)
            {
                libro.AgregarAutor(autor);
            }
        }
        //igual al de arriba pero con Temas
        private void AsociarTemas(Libro libro, IEnumerable<int> temasIds, List<string> errores)
        {
            var ids = temasIds.Distinct().ToList();
            var temas = _unitOfWork.Temas.ObtenerPorIds(ids);
            if (temas.Count != ids.Count)
            {
                errores.Add("Alguno de los temas seleccionados no existe.");
                return;
            }
            foreach (var tema in temas)
            {
                libro.AgregarTema(tema);
            }
        }

        private void SincronizarAutores(Libro libro, IEnumerable<int> autoresIds, List<string> errores)
        {//este meotodo lo uso solo en editar, porque en agregar no hay que quitar nada, solo agregar los seleccionados
            var idsDeseados = autoresIds.Distinct().ToList();
            // Se quitan los autores que ya no están seleccionados
            foreach (var autor in libro.Autores.Where(a => !idsDeseados.Contains(a.AutorId)).ToList())
            {
                libro.Autores.Remove(autor);
            }
            // Se agregan solamente los nuevos
            var idsNuevos = idsDeseados
                .Except(libro.Autores.Select(a => a.AutorId))
                .ToList();
            if (idsNuevos.Any())
            {
                AsociarAutores(libro, idsNuevos, errores);
            }
        }

        private void SincronizarTemas(Libro libro, IEnumerable<int> temasIds, List<string> errores)
        {
            var idsDeseados = temasIds.Distinct().ToList();
            foreach (var tema in libro.Temas.Where(t => !idsDeseados.Contains(t.TemaId)).ToList())
            {
                libro.Temas.Remove(tema);
            }
            var idsNuevos = idsDeseados
                .Except(libro.Temas.Select(t => t.TemaId))
                .ToList();
            if (idsNuevos.Any())
            {
                AsociarTemas(libro, idsNuevos, errores);
            }
        }

    }
}
