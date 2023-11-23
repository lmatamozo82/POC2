using Microsoft.AspNetCore.Builder;
using Deneva.Adapters.Database.MySQL.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Deneva.Adapters.Database.MySQL.Interfaces;
using Deneva.Adapters.Database.MySQL.Models;
using Deneva.Adapters.Database.MySQL.Services;

namespace Deneva.Adapters.WebAPI.Playlist.Host.Configuration
{
    public static class ConfigureDBService
    {
        public static void AddDBService(this IServiceCollection services, IConfiguration configuration)
        {
            //LMM, aqui hay que poner el select case con el setting para el sistema de Bse de Datos. De momento solo esta el adapter de MySQL.           
            services.AddMySQLService(configuration);



            //Esto es independiente del motor de BBDD. Son servicios que tienen que ir con cualquier proveedor.
            services.AddScoped<DatabaseConfig>();
            services.AddScoped<IDatabaseCacheService, DatabaseCacheService>();
        }
    }
}
