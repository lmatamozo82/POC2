using Microsoft.Extensions.DependencyInjection;
using Deneva.Adapters.WebAPI.Playlist.Host.Filters;

namespace Deneva.Adapters.WebAPI.Playlist.Host.Configuration
{
    public static class ConfigureFilters
    {
        public static void RegisterFilters(this IServiceCollection services)
        {
            services.AddControllersWithViews(options => 
            {
                options.Filters.Add<ValidateRequestFilter>();
            }).AddXmlSerializerFormatters(); //LMM, esto es para aceptar los formateadores de XML.

            services.AddScoped<ValidateRequestFilter>();
        }
    }
}
