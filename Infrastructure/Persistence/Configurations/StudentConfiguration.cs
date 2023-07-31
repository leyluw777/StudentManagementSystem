using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Configurations
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>

    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.Property(x=>x.LastLoginDate).IsRequired();
            builder.Property(x=>x.AverageGrade).IsRequired();
            builder.Property(x=>x.Address).IsRequired();
            builder.Property(x=>x.Status).IsRequired();
            builder.Property(x=>x.GraduatedStatus).IsRequired(false);
            builder.Property(x=>x.LeftStatus).IsRequired(false);
            builder.Property(x=>x.StoppedStatus).IsRequired(false);
            builder.Property(x => x.Marks).IsRequired();
            builder.Property(x => x.PhoneNumbers).IsRequired();
            builder.Property(x => x.Attendances).IsRequired();
            builder.Property(x => x.Courses).IsRequired();
            builder.Property(x => x.Groups).IsRequired();
          
        }
    }
}
