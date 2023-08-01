using SMSDomain.Entities;
using SMSDomain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Configurations
{
    public class AssessmentConfiguration //: IEntityTypeConfiguration<Assessment>
    {
        public void Configure(EntityTypeBuilder<Assessment> builder)
        {
            builder.ConfigureAuditableBaseEntity<Assessment>();
            //builder.Property(c => c.Mark).IsRequired();
            builder.Property(c => c.AssessmentType).IsRequired();

            builder.HasOne(x => x.Mark)
                    .WithMany(h => h.Assessments)
                    .HasForeignKey(x => x.MarkId)
                    .IsRequired();
      }
    }
}
