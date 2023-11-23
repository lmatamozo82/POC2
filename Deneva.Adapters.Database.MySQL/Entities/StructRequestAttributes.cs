using Deneva.Core.Domain.Builders.RequestAttributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deneva.Adapters.Database.MySQL.Entities
{
    public class StructRequestAttributes
    {
        public int ObjectID { get; set; }
        public int Empresa { get; set; }
        public string PID { get; set; }
    }
}
