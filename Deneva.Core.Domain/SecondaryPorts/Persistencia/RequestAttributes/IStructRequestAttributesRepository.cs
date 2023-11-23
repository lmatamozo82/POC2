using Deneva.Core.Domain.Models.RequestAttributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deneva.Core.Domain.SecondaryPorts.Persistencia.RequestAttributes
{
    public interface IStructRequestAttributesRepository : IRepository<StructRequestAttributes>
    {
        Task<IEnumerable<StructRequestAttributes>> GetAllAsync();
        Task<StructRequestAttributes> GetByObjIDAsync(int objID);
        Task<StructRequestAttributes> GetByPIDAsync(string PID);
    }
}
