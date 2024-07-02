using KSP.BiblioNet.Api;
using KSP.BiblioNet.Application;
using KSP.BiblioNet.Common;
using KSP.BiblioNet.External;
using KSP.BiblioNet.Persistence;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddWebApi()
    .AddCommon()
    .AddApplication()
    .AddExternal(builder.Configuration)
    .AddPersistence(builder.Configuration);

// Configurar CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        policy =>
        {
            policy.WithOrigins("*") // Asegúrate de usar la URL de tu frontend
                  .AllowAnyMethod()
                  .AllowAnyHeader();
        });
});

// Configuracion para que el cliente puede usar el controlador
builder.Services.AddControllers();

var app = builder.Build();

// Usar CORS
app.UseCors("AllowSpecificOrigin");

// Despu[es esta linea para poder usar los controadores
app.MapControllers();

app.Run();