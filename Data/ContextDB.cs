using Microsoft.EntityFrameworkCore;
using Prog3Api.NET.Models;

namespace Prog3Api.NET.Data
{
    //Heredar clase de Entity Framework para administrar base de datos
    public class ContextDB : DbContext
    {
        //Heredar opciones por defecto de la clase base
        public ContextDB(DbContextOptions<ContextDB> options) : base(options) 
        {
        }

        //DbSet: creación de tabla <Model de tabla a crear>
        public DbSet<Persona> Personas { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
    }
}
