using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Deneva.Adapters.Database.MySQL.Entities;

namespace Deneva.Adapters.Database.MySQL.Context
{
    public class StructRequestAttributesContext : DbContext
    {
        public StructRequestAttributesContext(DbContextOptions<StructRequestAttributesContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //LMM, mapeo de tablas a entidades
            modelBuilder.Entity<StructRequestAttributes>().ToTable("licencias_empresas");

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public async Task<bool> Commit()
        {
            return await base.SaveChangesAsync() > 0;
        }
    }
}
