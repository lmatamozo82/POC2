using Deneva.Adapters.Database.MySQL.Context;
using Deneva.Adapters.Database.MySQL.Interfaces;
using Deneva.Adapters.Database.MySQL.Models;
using Deneva.Adapters.Database.MySQL.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deneva.Adapters.Database.MySQL.Configuration
{
    public static class ServiceConfiguration
    {
        public static void AddMySQLService(this IServiceCollection services, IConfiguration configuration)
        {
            var _connectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContextFactory<StructRequestAttributesContext>(options =>
            {
                options.UseMySql(_connectionString, ServerVersion.AutoDetect(_connectionString), sql => sql.EnableRetryOnFailure(maxRetryCount: 4, maxRetryDelay: TimeSpan.FromSeconds(1), errorNumbersToAdd: new int[] { }));
                options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            });

            //services.AddScoped<DatabaseConfig>();
            //services.AddScoped<IDatabaseCacheService, DatabaseCacheService>();
        }

    }
}
