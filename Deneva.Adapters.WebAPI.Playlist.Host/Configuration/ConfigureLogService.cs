using Deneva.Adapters.Log.SerilogSystem;
using Microsoft.AspNetCore.Builder;
using System.Reflection;

namespace Deneva.Adapters.WebAPI.Playlist.Host.Configuration
{
    public static class ConfigureLogService
    {
        public static void AddLogService(this WebApplicationBuilder builder)
        {
            //LMM, aqui hay que poner el select case con el setting para el sistema de log. De momento solo esta el adapter de serilog.
            builder.AddSerilog(Assembly.GetExecutingAssembly().GetName().Name);


           //return builder;
        }
    }
}
