using System.Text.Json.Serialization;
using BibliotecaAPI.Datos;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// �rea de servicios

builder.Services.AddControllers().AddJsonOptions(opciones => opciones.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

builder.Services.AddDbContext<ApplicationDBContext>(opciones => 
    opciones.UseSqlServer("name=DefualtConnection"));

var app = builder.Build();

// �rea de middlewares

app.MapControllers();

//app.MapGet("/", () => "Hello World!");

app.Run();
