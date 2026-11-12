using TpLibreria.Entidades;
using TpLibreria.Servicios.DTOs.Cliente;

namespace TpLibreria.Servicios.Mapeadores
{
    public static class ClienteMapper
    {
        public static ClienteListDto ToListDto(Cliente cliente)
        {
            return new ClienteListDto
            {
                ClienteId = cliente.ClienteId,
                Nombre = cliente.Nombre,
                Apellido = cliente.Apellido,
                Email = cliente.Email,
                Telefono = cliente.Telefono
            };
        }

        public static Cliente ToEntidad(ClienteCreateDto clienteDto)
        {
            return new Cliente
            {
                Nombre = clienteDto.Nombre,
                Apellido = clienteDto.Apellido,
                Email = clienteDto.Email,
                Telefono = clienteDto.Telefono,
                
            };
        }

        public static Cliente ToEntidad(ClienteUpdateDto clienteDto)
        {
            return new Cliente
            {
                ClienteId = clienteDto.ClienteId,
                Nombre = clienteDto.Nombre,
                Apellido = clienteDto.Apellido,
                Email = clienteDto.Email,
                Telefono = clienteDto.Telefono,
                RowVersion = clienteDto.RowVersion,
            };
        }

        public static ClienteUpdateDto ToUpdateDto(Cliente cliente)
        {
            return new ClienteUpdateDto
            {
                ClienteId = cliente.ClienteId,
                Nombre = cliente.Nombre,
                Apellido = cliente.Apellido,
                Email = cliente.Email,
                Telefono = cliente.Telefono,
                RowVersion = cliente.RowVersion,
            };
        }

        public static ClienteDeleteDto ToDeleteDto(Cliente cliente)
        {
            return new ClienteDeleteDto
            {
                ClienteId = cliente.ClienteId,
                RowVersion = cliente.RowVersion,
            };
        }

        public static ClienteComboDto ToComboDto(Cliente cliente)
        {
            return new ClienteComboDto
            {
                ClienteId = cliente.ClienteId,
                NombreCompleto = cliente.NombreCompleto,
                Email = cliente.Email,
                Telefono = cliente.Telefono
            };
        }
    }
}
