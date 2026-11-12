using TpLibreria.Entidades;

namespace TpLibreria.Windows.Classes
{
    public static class UsuariosSistema
    {
        public static List<Usuario> Usuarios { get; } =
                [
                    new Usuario
            {
                UserName = "admin",
                Password = "123456" // Mínimo 6 caracteres
            },
            new Usuario
            {
                UserName = "empleado",
                Password = "123456" // Mínimo 6 caracteres
            }
                ];
    }
}
