using Deneva.Adapters.Database.MySQL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deneva.Adapters.Database.MySQL.Context.Configs
{
    public class StructRequestAttributesConfig : IEntityTypeConfiguration<StructRequestAttributes>
    {
        public void Configure(EntityTypeBuilder<StructRequestAttributes> builder)
        {
            builder.HasKey(x => x.PID);
            builder.Property(x => x.ObjectID).IsRequired();
            builder.Property(x => x.Empresa).HasColumnName("Empresa_Cliente");
            builder.HasQueryFilter(x => x.ObjectID != default);
        }
    }
}
