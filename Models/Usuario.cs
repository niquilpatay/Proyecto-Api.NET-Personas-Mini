using System.ComponentModel.DataAnnotations.Schema;

namespace Prog3Api.NET.Models
{
    //Indicar tabla SQL
    [Table("usuarios")]
    public class Usuario
    {
        public int Id { get; set; } //Atributo Id genera automáticamente la PK al realizar la migración
        public string NombreUsu { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
