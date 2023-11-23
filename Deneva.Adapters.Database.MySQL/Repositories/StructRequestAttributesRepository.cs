using Deneva.Adapters.Database.MySQL.Context;
using Deneva.Adapters.Database.MySQL.Entities;
using Deneva.Adapters.Database.MySQL.Interfaces;
using Deneva.Adapters.Database.MySQL.Mappers;
using Deneva.Core.Domain.SecondaryPorts.Persistencia;
using Deneva.Core.Domain.SecondaryPorts.Persistencia.RequestAttributes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Deneva.Adapters.Database.MySQL.Repositories
{
    public class StructRequestAttributesRepository : IStructRequestAttributesRepository
    {
        private readonly StructRequestAttributesContext _context;
        private readonly IDatabaseCacheService _cache;

        public StructRequestAttributesRepository(StructRequestAttributesContext context,IDatabaseCacheService cache)
        {
            _context = context;
            _cache = cache;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IUnitOfWork UnitOfWork => throw new NotImplementedException();

          public async Task<Core.Domain.Models.RequestAttributes.StructRequestAttributes> GetByObjIDAsync(int objID)
        {
            string cacheKey=_cache.GetCacheKey("FindByObjID".ToLower(),objID.ToString());

            if (!_cache.TryGetValue(cacheKey,out Entities.StructRequestAttributes data))
            {
                data = await _context.Set<StructRequestAttributes>().AsNoTracking().Where(d => d.ObjectID == objID).FirstOrDefaultAsync();

                if (data==null) { throw new KeyNotFoundException(); }

                _cache.SetValue(cacheKey, data);
            }
     
            return data.ToModel();
        }

        public async Task<Core.Domain.Models.RequestAttributes.StructRequestAttributes> GetByPIDAsync(string PID)
        {
            string cacheKey = _cache.GetCacheKey("FindByPID".ToLower(), PID);

            if (!_cache.TryGetValue(cacheKey, out Entities.StructRequestAttributes data))
            {
                data = await _context.Set<StructRequestAttributes>().AsNoTracking().Where(d => d.PID == PID).FirstOrDefaultAsync();
                
                if (data == null) { throw new KeyNotFoundException(); }

                _cache.SetValue(cacheKey, data);
            }

            return data.ToModel();
        }

        
        public async Task<IEnumerable<Core.Domain.Models.RequestAttributes.StructRequestAttributes>> GetAllAsync()
        {
            //LMM, GetAllAsync no tira de cache, de momento.
            var data = await _context.Set<StructRequestAttributes>().AsNoTracking().ToListAsync();
            return data.ToModel();
        }


    }
}
