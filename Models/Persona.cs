using System.ComponentModel.DataAnnotations.Schema;

namespace Prog3Api.NET.Models
{
    //Indicar tabla SQL
    [Table("personas")]
    public class Persona
    {
        public int Id { get; set; } //Atributo Id genera automáticamente la PK al realizar la migración
        public string Nombre { get; set; }
    }
}
