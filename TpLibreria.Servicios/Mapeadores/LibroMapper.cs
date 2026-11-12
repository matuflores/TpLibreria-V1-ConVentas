using TpLibreria.Entidades;
using TpLibreria.Entidades.Enums;
using TpLibreria.Servicios.DTOs.Libro;

namespace TpLibreria.Servicios.Mapeadores
{
    public static class LibroMapper
    {
        public static LibroListDto ToListDto(Libro libro)
        {
            return new LibroListDto
            {
                LibroId = libro.LibroId,
                Tipo = libro.Tipo == TipoLibro.Fisico ? "Físico" : "Digital",
                Codigo = libro switch
                {
                    LibroFisico fisico => fisico.Isbn,
                    LibroDigital digital => digital.Identificador,
                    _ => string.Empty
                },
                Titulo = libro.Titulo,
                Editorial = libro.Editorial.Nombre,
                Autores = string.Join(", ", libro.Autores
                    .OrderBy(a => a.Apellido).ThenBy(a => a.Nombre)
                    .Select(a => a.NombreCompleto)),
                Precio = libro.Precio,
                Stock = (libro as LibroFisico)?.Stock,
                Activo = libro.Activo
            };
        }

        public static LibroComboDto ToComboDto(Libro libro)
        {
            var fisico = libro as LibroFisico;
            return new LibroComboDto
            {
                LibroId = libro.LibroId,
                Titulo = libro.Titulo,
                Tipo = fisico is null ? "Digital" : "Físico",
                Texto = fisico is null
                    ? $"{libro.Titulo} (Digital) - {libro.Precio:C2}"
                    : $"{libro.Titulo} (Físico, stock {fisico.Stock}) - {libro.Precio:C2}",
                Precio = libro.Precio,
                EsFisico = fisico is not null,
                Stock = fisico?.Stock ?? 0
            };
        }

        // Crea la entidad con los datos simples; los autores y temas se asocian en el servicio
        public static Libro ToEntidad(LibroCreateDto dto)
        {
            if (dto.Tipo == TipoLibro.Fisico)
            {
                return new LibroFisico
                {
                    Titulo = dto.Titulo,
                    Descripcion = dto.Descripcion,
                    AnioPublicacion = dto.AnioPublicacion,
                    Precio = dto.Precio,
                    EditorialId = dto.EditorialId,
                    Isbn = dto.Isbn!,
                    Stock = dto.Stock
                };
            }
            return new LibroDigital
            {
                Titulo = dto.Titulo,
                Descripcion = dto.Descripcion,
                AnioPublicacion = dto.AnioPublicacion,
                Precio = dto.Precio,
                EditorialId = dto.EditorialId,
                Identificador = dto.Identificador!,
                Formato = dto.Formato!,
                TamanoArchivo = dto.TamanoArchivo,
                UrlDescarga = dto.UrlDescarga!
            };
        }

        public static LibroUpdateDto ToUpdateDto(Libro libro)
        {
            var dto = new LibroUpdateDto
            {
                LibroId = libro.LibroId,
                Tipo = libro.Tipo,
                Titulo = libro.Titulo,
                Descripcion = libro.Descripcion,
                AnioPublicacion = libro.AnioPublicacion,
                Precio = libro.Precio,
                EditorialId = libro.EditorialId,
                AutoresIds = libro.Autores.Select(a => a.AutorId).ToList(),
                TemasIds = libro.Temas.Select(t => t.TemaId).ToList(),
                Activo = libro.Activo,
                RowVersion = libro.RowVersion
            };
            if (libro is LibroFisico fisico)
            {
                dto.Isbn = fisico.Isbn;
                dto.Stock = fisico.Stock;
            }
            else if (libro is LibroDigital digital)
            {
                dto.Identificador = digital.Identificador;
                dto.Formato = digital.Formato;
                dto.TamanoArchivo = digital.TamanoArchivo;
                dto.UrlDescarga = digital.UrlDescarga;
            }
            return dto;
        }

        public static LibroDeleteDto ToDeleteDto(Libro libro)
        {
            return new LibroDeleteDto
            {
                LibroId = libro.LibroId,
                RowVersion = libro.RowVersion,
            };
        }
    }
}
