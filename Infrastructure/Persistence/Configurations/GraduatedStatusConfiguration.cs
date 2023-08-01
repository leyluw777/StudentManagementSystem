using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Configurations
{
    public class GraduatedStatusConfiguration //: IEntityTypeConfiguration<GraduatedStatus>
    {
        public void Configure(EntityTypeBuilder<GraduatedStatus> builder)
        {
            builder.ConfigureAuditableBaseEntity<GraduatedStatus>();
            //builder.Property(x => x.Student).IsRequired();
            builder.Property(x => x.GraduatedDate).IsRequired();
          
    
        }
    }
}
