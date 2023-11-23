using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.SystemConsole.Themes;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;

namespace Deneva.Adapters.Log.SerilogSystem
{
    public static class SerilogExtension
    {
        //LMM. Manejo los distintos niveles de log minimos por servicios directamente en el appsettings.json.
        public static void AddSerilog(this WebApplicationBuilder builder,string AssemblyName)
        {
            var fileName = Path.Combine(builder.Configuration["RutaLog"], AssemblyName + ".log");
            Serilog.Log.Logger = new LoggerConfiguration()
                .WriteTo.Console(theme: AnsiConsoleTheme.Literate, outputTemplate: "[{Timestamp:HH:mm:ss}][{Level:u3}][{Message:lj}]{NewLine}")
                .WriteTo.File(
                    path: fileName,
                    rollingInterval: RollingInterval.Day,
                    restrictedToMinimumLevel: LogEventLevel.Verbose,
                    flushToDiskInterval: TimeSpan.FromSeconds(1),
                    outputTemplate: "[{Timestamp:HH:mm:ss.fff}][{Level:u3}][{Message:lj}]{NewLine}")
                .ReadFrom.Configuration(builder.Configuration)
                .CreateLogger();

            Serilog.Log.Information("----------------------------------------------------------------------------------");
            Serilog.Log.Information("-------------- " + AssemblyName + " ------------");
            Serilog.Log.Information("----------------------------------------------------------------------------------");

            builder.Host.UseSerilog();

            builder.Logging.AddSerilog(Serilog.Log.Logger);

            //return builder;
        }
    }
}
