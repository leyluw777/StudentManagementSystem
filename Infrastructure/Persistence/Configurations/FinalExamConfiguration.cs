using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Configurations
{
    public class FinalExamConfiguration : IEntityTypeConfiguration<FinalExam>
    {
        public void Configure(EntityTypeBuilder<FinalExam> builder)
        {
            builder.ConfigureAuditableBaseEntity<FinalExam>();
            builder.Property(x => x.Course).IsRequired();
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.UsedTechnologies).IsRequired(false);
            builder.Property(x => x.ExamDate).IsRequired();
            builder.Property(x => x.Mark).IsRequired();

            builder.HasOne(x => x.Mark)
                .WithOne(x => x.FinalExam)
                .HasForeignKey<FinalExam>(h => h.MarkId)
                .IsRequired();
        }
    }
}
