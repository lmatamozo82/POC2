using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deneva.Adapters.Database.MySQL.Models
{
    public class DatabaseConfig
    {
        private readonly IConfiguration _configuration;
        public double CacheExpirationInSeconds { get; set; }

        public DatabaseConfig(IConfiguration configuration) 
        {
            _configuration = configuration;
            CacheExpirationInSeconds = _configuration.GetValue<double>("SegundosCache");
        }
    }
}
