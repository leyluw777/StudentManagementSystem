using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Configurations
{
    public class LeftStatusConfiguration //: IEntityTypeConfiguration<LeftStatus>
    {
        public void Configure(EntityTypeBuilder<LeftStatus> builder)
        {
            builder.ConfigureAuditableBaseEntity<LeftStatus>();
            builder.Property(x=> x.LeftDate).IsRequired();
            builder.Property(x=> x.LeftMessage).IsRequired(false);
            //builder.Property(x=> x.Student).IsRequired();
            
           // builder.HasOne(x=>x.Student).WithOne(x=>x.LeftStatus).HasForeignKey<LeftStatus>(y=> y.StudentId).IsRequired();  

        }
    }
}
