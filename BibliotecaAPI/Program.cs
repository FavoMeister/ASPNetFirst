using System.Text.Json.Serialization;
using BibliotecaAPI;
using BibliotecaAPI.Datos;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Área de servicios

builder.Services.AddControllers().AddJsonOptions(opciones => opciones.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

builder.Services.AddTransient<ServicioTransient>();
builder.Services.AddScoped<ServicioScoped>();
builder.Services.AddSingleton<ServicioSingleton>();

//builder.Services.AddTransient<RepositorioValores>();
//builder.Services.AddTransient<IRepositorioValores, RepositorioValores>();
builder.Services.AddTransient<IRepositorioValores, RepositorioValoresOracle>();

builder.Services.AddDbContext<ApplicationDBContext>(opciones => 
    opciones.UseSqlServer("name=DefualtConnection"));

var app = builder.Build();

// Área de middlewares

app.MapControllers();

//app.MapGet("/", () => "Hello World!");

app.Run();
