using Infrastructure.Persistence.Configurations.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Configurations
{
    public class AttendanceConfiguration : IEntityTypeConfiguration<Attendance>
    {
        public void Configure(EntityTypeBuilder<Attendance> builder)
        {
            builder.ConfigureAuditableBaseEntity<Attendance>();

            builder.Property(x => x.Student).IsRequired();
            builder.Property(x => x.Status).IsRequired();
            builder.Property(x => x.AttendanceDate).IsRequired();
            builder.Property(x => x.Lesson).IsRequired();
            builder.Property(x => x.SharedNotes).IsRequired(false);
            builder.Property(x => x.InternalNotes).IsRequired(false);


            builder.HasOne(x => x.Student)
                .WithMany(h => h.Attendances)
                .HasForeignKey(x => x.StudentId)
                .IsRequired();

            builder.HasOne(x => x.Lesson)
               .WithMany(h => h.Attendances)
               .HasForeignKey(x => x.LessonId)
               .IsRequired();
        }
    }
}
