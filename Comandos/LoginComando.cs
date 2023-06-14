using Microsoft.Extensions.Primitives;

namespace Prog3Api.NET.Comandos
{
    //Crear comando de inicio de sesión
    public class LoginComando
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
