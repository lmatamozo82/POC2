using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deneva.Core.Domain.SecondaryPorts.Persistencia
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
    }
}
