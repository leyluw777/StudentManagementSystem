using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Configurations
{
    public class ModuleConfiguration// : IEntityTypeConfiguration<Module>
    {
        public void Configure(EntityTypeBuilder<Module> builder)
        {
            builder.ConfigureAuditableBaseEntity<Module>();
            builder.Property(e => e.Name).IsRequired();
            //builder.Property(e => e.Course).IsRequired();
            builder.Property(e => e.TotalHours).IsRequired();


        }
    }
}
