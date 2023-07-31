using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Configurations
{
    public class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.ConfigureAuditableBaseEntity<Course>();
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.JoinedDate).IsRequired();
            builder.Property(x => x.TotalHours).IsRequired();
            builder.Property(x => x.TotalModules).IsRequired();
            builder.Property(x => x.FinalExam).IsRequired();
            builder.Property(x => x.Users).IsRequired();
            builder.Property(x => x.Modules).IsRequired();
            builder.Property(x => x.Teachers).IsRequired();
            builder.Property(x => x.Coordinators).IsRequired();

            builder.HasOne(x => x.FinalExam)
                .WithOne(x => x.Course)
                .HasForeignKey<Course>(h => h.FinalExamId)
                .IsRequired();


        }
    }
}
