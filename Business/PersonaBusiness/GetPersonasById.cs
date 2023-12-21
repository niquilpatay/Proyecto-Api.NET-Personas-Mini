using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Prog3Api.NET.Data;
using Prog3Api.NET.Models;

namespace Prog3Api.NET.Business.PersonaBusiness
{
    public class GetPersonasById
    {
        //Implementar interfaz de MediatR para el model Persona
        public class GetPersonaByIdComando : IRequest<Persona>
        {
            //Ingresar id a buscar
            public int IdPersona { get; set; } 
        }

        //Crear clase que ejecute una validación, heredar clase de FluentValidation para utilizar con el constructor GetPersonaByIdComando
        public class EjecutaValidacion : AbstractValidator<GetPersonaByIdComando>
        {
            public EjecutaValidacion()
            {
                //Método que verifica si en el Id ingresado existe una persona
                RuleFor(p => p.IdPersona).NotEmpty();
            }
        }

        //Implementar interfaz de MediatR para manejar constructor y model
        public class Manejador : IRequestHandler<GetPersonaByIdComando, Persona>
        {
            //Proveer de contexto en constructor
            private readonly ContextDB _contexto;
            public Manejador(ContextDB context)
            {
                _contexto = context;
            }

            //Método de Interfaz implementada a sobreescribir, recibe un comando con un id y un token
            public async Task<Persona> Handle(GetPersonaByIdComando comando, CancellationToken cancellationToken)
            {
                //Devuelve como resultado una persona
                var result = new Persona();

                try
                {
                    //Busca a una persona utilizando el contexto y su tabla Personas
                    result = await _contexto.Personas.FirstOrDefaultAsync(c => c.Id == comando.IdPersona);
                    if (result != null)
                    {
                        //Si el resultado no es nulo, devuelve resultado
                        return result;
                    }
                    else
                    {
                        //Lanzar excepción en caso de error
                        throw new Exception("No se encontró ninguna persona con el ID especificado.");
                    }
                }
                catch (Exception ex)
                {
                    //Mostrar mensaje de error
                    Console.WriteLine("Error al obtener la persona: " + ex.Message);
                    throw;
                }
            }
        }
    }
}
