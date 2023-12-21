using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Prog3Api.NET.Comandos;
using Prog3Api.NET.Data;
using Prog3Api.NET.Models;
using Prog3Api.NET.Resultados;

namespace Prog3Api.NET.Controllers
{
    //Tipo de controlador API, heredar clase ControllerBasse
    [ApiController]
    public class PersonaController : ControllerBase
    {
        //Proveer contexto e interfaz mediador en constructor
        private readonly ContextDB _contexto;
        private readonly IMediator _mediator;
        public PersonaController(ContextDB contexto, IMediator mediator)
        {
            _contexto = contexto;
            _mediator = mediator;
        }

        //Buscar todas las personas
        //Devuelve un resultado de la acción y una lista de personas
        [HttpGet]
        [Route("api/personas/getPersonas")]
        public ActionResult<List<Persona>> GetPersonas()
        {
            //Pasar tabla Personas en contexto a una lista
            var personas = _contexto.Personas.ToList();
            //Devolver resultado
            return Ok(personas);
        }

        //Buscar personas por Id
        //Ingresar id en ruta
        //Devuelve una persona
        [HttpGet]
        [Route("api/personas/getPersonaById/{id}")]
        public async Task<Persona> GetPersonaById(int id)
        {
            //FORMA 1
            //var persona = _contexto.Personas.Where(c => c.Id == id).FirstOrDefault();
            //return Ok(persona);

            //FORMA 2
            //Utilizar interfaz mediadora: enviar método para buscar personas por id para que el mismo sea manejado
            return await _mediator.Send(new Business.PersonaBusiness.GetPersonasById.GetPersonaByIdComando
            {
                IdPersona = id
            });
        }


        //GET (VIDEOS MATERIAL)
        //Devuelve un resultado con una clase definida por nosotros
        [HttpGet]
        [Route("api/usuario/getUsuarios")]
        public async Task<ResultadoBase> GetUsuarios()
        {
            //Devuelve una lista de usuarios 
            var resultado = new UsuarioResultado();

            //Asignacion de valores a resultado
            resultado.ListaUsuarios = await _contexto.Usuarios.ToListAsync();
            resultado.Ok = true;
            resultado.StatusCode = 200;

            //Devolucion de resultado
            return resultado;
        }

        //POST (VIDEOS MATERIAL)
        //Devuelve un resultado con una clase definida por nosotros
        //Recibe un comando de login
        [HttpPost]
        [Route("api/usuario/login")]
        public async Task<LoginResultado> Login(LoginComando comando)
        {
            var resultado = new LoginResultado();

            //Compara las credenciales ingresadas en el comando con las existentes en todos los usuarios
            var usuario = await _contexto.Usuarios.FirstOrDefaultAsync(c => c.Email.Equals(comando.Email) && c.Password.Equals(comando.Password));
            if(usuario == null)
            {
                //Si no existe un usuario que coincida con las credenciales, devolver error
                resultado.SetError("Email/Password incorrecto");
                return resultado;   
            }

            //Asignación de valores y devolución de resultado
            resultado.LoginResult = true;
            resultado.Ok = true;
            resultado.StatusCode = 200;
            return resultado;
        }
    }
}
