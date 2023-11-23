using Deneva.Core.Domain.Models.RequestAttributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deneva.Core.Domain.Builders.RequestAttributes
{
    public class StructRequestAttributesBuilder
    {
        public int ObjectID { get; set; }
        public int Empresa { get; set; }
        public string PID { get; set; }

        public StructRequestAttributesBuilder() { }

        public StructRequestAttributesBuilder WithObjectID(int objID) 
        { 
            this.ObjectID = objID;
            return this;
        }

        public StructRequestAttributesBuilder WithEmpresa(int Empresa)
        {
            this.Empresa = Empresa;
            return this;
        }

        public StructRequestAttributesBuilder WithPID(string PID)
        {
            this.PID = PID;
            return this;
        }

        public StructRequestAttributes Build()
        {
            return new StructRequestAttributes(this);
        }
    }
}
