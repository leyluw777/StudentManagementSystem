using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Configurations
{
    public class MarkConfiguration //: IEntityTypeConfiguration<Mark>
    {
        public void Configure(EntityTypeBuilder<Mark> builder)
        {
            builder.ConfigureAuditableBaseEntity<Mark>();
            builder.Property(x => x.Points).IsRequired();
            builder.Property(x => x.MaxPoints).IsRequired();
            builder.Property(x => x.OverallGrade).IsRequired();
            //builder.Property(x => x.FinalExam).IsRequired();
            //builder.Property(x => x.Student).IsRequired();

            builder.HasOne(x => x.FinalExam)
                .WithOne(x => x.Mark)
                .HasForeignKey<Mark>(y => y.FinalExamId)
                .IsRequired();


            builder.HasOne(x => x.Student)
                .WithMany(x => x.Marks)
                .HasForeignKey(y => y.StudentId)
                .IsRequired();
        }
    }
}
