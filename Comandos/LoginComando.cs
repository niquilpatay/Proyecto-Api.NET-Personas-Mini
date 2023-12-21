using Microsoft.Extensions.Primitives;
using System.ComponentModel.DataAnnotations;

namespace Prog3Api.NET.Comandos
{
    //Crear comando de inicio de sesión
    public class LoginComando
    {
        public string Email { get; set; }
        public string Password { get; set; }

        public LoginComando(string email, string password)
        {
            Email = email;
            Password = password;
        }

    }
}
