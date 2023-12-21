using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Prog3Api.NET.Business.PersonaBusiness;
using Prog3Api.NET.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Añadir DbContext
builder.Services.AddDbContext<ContextDB>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("ConexionDatabase"));
});

//Añadir MediaTR
builder.Services.AddMediatR(typeof(GetPersonasById).Assembly);

var app = builder.Build();

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();

//INSTALAR PAQUETES:
//Microsoft.EntityFrameworkCore
//Microsoft.EntityFrameworkCore.Analyzers
//Microsoft.EntityFrameworkCore.Design
//Microsoft.EntityFrameworkCore.Tools
//MediatR.Extensions.Microsoft.DependencyInjection
//FluentValidation.AspNetCore
//Npgsql.EntityFrameworkCore.PostgreSQL

//CREAR BD DE EJEMPLO (POSTGRE SQL):
//1. Conectar a PostgreSQL y crear un usuario de ejemplo "user_ejemplo" -> asignar contraseña a usuario
//2. Otorgar privilegios a usuario: Can login? - Create databases?
//3. Ir a appsettings.Development.json y añadir código:
/*  
    "ConnectionStrings": {
    "ConexionDatabase": "Server=localhost;Database=api_ejemplo;Port:5432;User Id=user_ejemplo;Password:123456;"
  },
*/
//4. Crear clases CodeFirst en ContextDB y Models
//5. Ver -> Otras Ventanas -> Consola del Administrador de paquetes
//6. COMANDOS:
//add-migration primerMigracion
//update-database