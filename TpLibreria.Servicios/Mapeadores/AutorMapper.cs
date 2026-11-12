using TpLibreria.Entidades;
using TpLibreria.Servicios.DTOs.Autor;

namespace TpLibreria.Servicios.Mapeadores
{
    public static class AutorMapper
    {
        public static AutorListDto ToListDto(Autor autor)
        {
            return new AutorListDto
            {
                AutorId = autor.AutorId,
                Nombre = autor.Nombre,
                Apellido = autor.Apellido,
                FechaNacimiento = autor.FechaNacimiento,
                Nacionalidad = autor.Nacionalidad
            };
        }

        public static Autor ToEntidad(AutorCreateDto autorDto)
        {
            return new Autor
            {
                Nombre = autorDto.Nombre,
                Apellido = autorDto.Apellido,
                FechaNacimiento = autorDto.FechaNacimiento,
                Nacionalidad = autorDto.Nacionalidad,
                
            };
        }

        public static Autor ToEntidad(AutorUpdateDto autorDto)
        {
            return new Autor
            {
                AutorId = autorDto.AutorId,
                Nombre = autorDto.Nombre,
                Apellido = autorDto.Apellido,
                FechaNacimiento = autorDto.FechaNacimiento,
                Nacionalidad = autorDto.Nacionalidad,
                RowVersion = autorDto.RowVersion,
            };
        }

        public static AutorUpdateDto ToUpdateDto(Autor autor)
        {
            return new AutorUpdateDto
            {
                AutorId = autor.AutorId,
                Nombre = autor.Nombre,
                Apellido = autor.Apellido,
                FechaNacimiento = autor.FechaNacimiento,
                Nacionalidad = autor.Nacionalidad,
                RowVersion = autor.RowVersion,
            };
        }

        public static AutorDeleteDto ToDeleteDto(Autor autor)
        {
            return new AutorDeleteDto
            {
                AutorId = autor.AutorId,
                RowVersion = autor.RowVersion,
            };
        }

        public static AutorComboDto ToComboDto(Autor autor)
        {
            return new AutorComboDto
            {
                AutorId = autor.AutorId,
                NombreCompleto = autor.NombreCompleto
            };
        }
    }
}
