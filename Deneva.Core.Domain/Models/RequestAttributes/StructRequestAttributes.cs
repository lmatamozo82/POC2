using Deneva.Core.Domain.Builders.RequestAttributes;
using Deneva.Core.Domain.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deneva.Core.Domain.Models.RequestAttributes
{
    public class StructRequestAttributes : IAggregateRoot
    {
        public int ObjectID { get; set; }
        public int Empresa { get; set; }
        public string PID { get; set; }


        public StructRequestAttributes(StructRequestAttributesBuilder builder)
        {
            ObjectID = builder.ObjectID;
            Empresa = builder.Empresa;
            PID = builder.PID;
        }
    }
}