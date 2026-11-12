using TpLibreria.Entidades;
using TpLibreria.Servicios.DTOs.Editorial;

namespace TpLibreria.Servicios.Mapeadores
{
    public static class EditorialMapper
    {
        public static EditorialListDto ToListDto(Editorial editorial)
        {
            return new EditorialListDto
            {
                EditorialId = editorial.EditorialId,
                Nombre = editorial.Nombre,
                PaisOrigen = editorial.PaisOrigen,
                Activo = editorial.Activo
            };
        }

        public static Editorial ToEntidad(EditorialCreateDto editorialDto)
        {
            return new Editorial
            {
                Nombre = editorialDto.Nombre,
                PaisOrigen = editorialDto.PaisOrigen,
                Activo = true,
            };
        }

        public static Editorial ToEntidad(EditorialUpdateDto editorialDto)
        {
            return new Editorial
            {
                EditorialId = editorialDto.EditorialId,
                Nombre = editorialDto.Nombre,
                PaisOrigen = editorialDto.PaisOrigen,
                Activo = editorialDto.Activo,
                RowVersion = editorialDto.RowVersion,
            };
        }

        public static EditorialUpdateDto ToUpdateDto(Editorial editorial)
        {
            return new EditorialUpdateDto
            {
                EditorialId = editorial.EditorialId,
                Nombre = editorial.Nombre,
                PaisOrigen = editorial.PaisOrigen,
                Activo = editorial.Activo,
                RowVersion = editorial.RowVersion,
            };
        }

        public static EditorialDeleteDto ToDeleteDto(Editorial editorial)
        {
            return new EditorialDeleteDto
            {
                EditorialId = editorial.EditorialId,
                RowVersion = editorial.RowVersion,
            };
        }

        public static EditorialComboDto ToComboDto(Editorial editorial)
        {
            return new EditorialComboDto
            {
                EditorialId = editorial.EditorialId,
                Nombre = editorial.Nombre
            };
        }
    }
}
