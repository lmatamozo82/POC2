using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Deneva.Adapters.WebAPI.Playlist.Host.Configuration;
using Deneva.Services.Playlist.Playlist.Infraestructura.Headers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

//LMM, añado aqui las cabeceras que necesito que vayan en cada petición
builder.Services.AddSwaggerGen(c =>
{
    c.OperationFilter<CustomXPIDHeader>();
    c.OperationFilter<CustomXTokenHeader>();
    c.OperationFilter<CustomIfModifiedSinceHeader>();
});


//LMM, registramos sistema de log.
builder.AddLogService();

//LMM, registramos el sistema de BBDD.
builder.Services.AddDBService(builder.Configuration);

//LMM, registramos los servicios en el DI que necesitamos.
builder.Services.RegisterServices();

//LMM, registramos los filtros de validación.
builder.Services.RegisterFilters();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseStaticFiles();
app.UseAuthorization();

app.MapControllers();

app.Run();
