using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Configurations
{
    public class HomeworkConfiguration : IEntityTypeConfiguration<Homework>
    {
        public void Configure(EntityTypeBuilder<Homework> builder)
        {
            builder.ConfigureAuditableBaseEntity <Homework>();
            builder.Property(x => x.Lesson).IsRequired();
            builder.Property(x => x.HomeworkDate).IsRequired();
            builder.Property(x => x.LessonName).IsRequired();
            builder.Property(x => x.FilesAttached).IsRequired();
            builder.Property(x => x.FilePath).IsRequired(false);
            builder.Property(x => x.Mark).IsRequired();
            builder.Property(x => x.Deadline).IsRequired();

            builder.HasOne(x => x.Mark).WithMany(x => x.Homeworks)
                .HasForeignKey(y => y.MarkId).IsRequired();

            builder.HasOne(x => x.Lesson).WithMany(x => x.Homeworks)
                .HasForeignKey(y => y.LessonId).IsRequired();
        }
    }
}
