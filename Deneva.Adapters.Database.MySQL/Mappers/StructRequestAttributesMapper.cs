using Deneva.Core.Domain.Builders.RequestAttributes;
using Deneva.Core.Domain.Models.RequestAttributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deneva.Adapters.Database.MySQL.Mappers
{
    public static class StructRequestAttributesMapper
    {
        public static StructRequestAttributes ToModel(this Entities.StructRequestAttributes entity)
        {
            var builder = new StructRequestAttributesBuilder()
                .WithObjectID(entity.ObjectID)
                .WithEmpresa(entity.Empresa)
                .WithPID(entity.PID);

            return builder.Build();             
        }

        public static IEnumerable<StructRequestAttributes> ToModel(this IEnumerable<Entities.StructRequestAttributes> entities) 
        {
            List<StructRequestAttributes> result = new();

            result.AddRange(entities.Select(x => x.ToModel()));

            return result;
        }
    }
}
