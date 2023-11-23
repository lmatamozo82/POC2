using Deneva.Core.Domain.Models.RequestAttributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deneva.Core.Domain.PrimaryPorts.RequestAttributes
{
    public interface IGetByPIDStructRequestAttributes
    {
        Task<StructRequestAttributes> ExecuteAsync(string PID);
    }
}
