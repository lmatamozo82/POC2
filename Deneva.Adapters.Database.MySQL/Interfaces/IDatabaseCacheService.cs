using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deneva.Adapters.Database.MySQL.Interfaces
{
    public interface IDatabaseCacheService
    {
        IMemoryCache GetCache();
        TimeSpan GetCacheExpiration();
        string GetCacheKey(string baseKey,string itemKey);
        bool IsCacheActive();
        bool TryGetValue<T>(string key, out T value);
        void SetValue<T>(string key, T value);
    }
}
