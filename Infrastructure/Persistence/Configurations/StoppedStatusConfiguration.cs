using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Configurations
{
    public class StoppedStatusConfiguration : IEntityTypeConfiguration<StoppedStatus>
    {
        public void Configure(EntityTypeBuilder<StoppedStatus> builder)
        {
            builder.ConfigureAuditableBaseEntity<StoppedStatus>();
            builder.Property(x=>x.StoppedMessage).IsRequired(false);
            builder.Property(x=>x.StoppedDate).IsRequired();
            builder.Property(x=>x.ApproximateStartDate).IsRequired(false);
        }
    }
}
