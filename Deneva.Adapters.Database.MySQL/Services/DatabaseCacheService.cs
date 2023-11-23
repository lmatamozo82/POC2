using Deneva.Adapters.Database.MySQL.Interfaces;
using Deneva.Adapters.Database.MySQL.Models;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deneva.Adapters.Database.MySQL.Services
{
    public class DatabaseCacheService : IDatabaseCacheService
    {
        private readonly DatabaseConfig _config;
        private readonly IMemoryCache _memCache;

        public DatabaseCacheService(DatabaseConfig config,IMemoryCache memCache) 
        {
            _config = config;
            _memCache = memCache;
        }
        public IMemoryCache GetCache()
        {
            return _memCache;
        }

        public TimeSpan GetCacheExpiration()
        {
            return TimeSpan.FromSeconds(_config.CacheExpirationInSeconds);
        }

        public string GetCacheKey(string baseKey, string itemKey)
        {
            return baseKey + itemKey;
        }

        public bool IsCacheActive()
        {
            return _config.CacheExpirationInSeconds != 0;   
        }

        public void SetValue<T>(string key, T value)
        {
            if (_config.CacheExpirationInSeconds > 0) 
            {
                var options=new MemoryCacheEntryOptions().SetAbsoluteExpiration(GetCacheExpiration());
                _memCache.Set(key, value,options);
            }
        }

        public bool TryGetValue<T>(string key, out T value)
        {
            if (_memCache ==null || _config.CacheExpirationInSeconds<=0) 
            {
                value = default(T);

                return false;
            }
            return _memCache.TryGetValue(key, out value);
        }
    }
}
