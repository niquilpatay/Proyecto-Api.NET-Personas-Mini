using Prog3Api.NET.Models;

namespace Prog3Api.NET.Resultados
{
    public class UsuarioResultado : ResultadoBase
    {
        //Devuelve lista de usuarios
        public List<Usuario> ListaUsuarios { get; set; }
    }
}
