using TpLibreria.Entidades;
using TpLibreria.Servicios.DTOs.Tema;

namespace TpLibreria.Servicios.Mapeadores
{
    public static class TemaMapper
    {
        public static TemaListDto ToListDto(Tema tema)
        {
            return new TemaListDto
            {
                TemaId = tema.TemaId,
                Nombre = tema.Nombre,
                Descripcion = tema.Descripcion
            };
        }

        public static Tema ToEntidad(TemaCreateDto temaDto)
        {
            return new Tema
            {
                Nombre = temaDto.Nombre,
                Descripcion = temaDto.Descripcion,
                
            };
        }

        public static Tema ToEntidad(TemaUpdateDto temaDto)
        {
            return new Tema
            {
                TemaId = temaDto.TemaId,
                Nombre = temaDto.Nombre,
                Descripcion = temaDto.Descripcion,
                RowVersion = temaDto.RowVersion,
            };
        }

        public static TemaUpdateDto ToUpdateDto(Tema tema)
        {
            return new TemaUpdateDto
            {
                TemaId = tema.TemaId,
                Nombre = tema.Nombre,
                Descripcion = tema.Descripcion,
                RowVersion = tema.RowVersion,
            };
        }

        public static TemaDeleteDto ToDeleteDto(Tema tema)
        {
            return new TemaDeleteDto
            {
                TemaId = tema.TemaId,
                RowVersion = tema.RowVersion,
            };
        }

        public static TemaComboDto ToComboDto(Tema tema)
        {
            return new TemaComboDto
            {
                TemaId = tema.TemaId,
                Nombre = tema.Nombre
            };
        }
    }
}
