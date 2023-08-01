using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Configurations
{
    public class QuizConfiguration// : IEntityTypeConfiguration<Quiz>
    {
        public void Configure(EntityTypeBuilder<Quiz> builder)
        {
            builder.ConfigureAuditableBaseEntity<Quiz>();
            //builder.Property(x => x.Module).IsRequired();
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.TopicsCovered).IsRequired(false);
            builder.Property(x => x.QuizDate).IsRequired(false);
            //builder.Property(x => x.Mark).IsRequired();


            builder.HasOne(x=> x.Module).WithMany(x=>x.Quizzes)
                .HasForeignKey(y=>y.ModuleId).IsRequired();

            builder.HasOne(x => x.Mark).WithMany(x => x.Quizzes)
                .HasForeignKey(y => y.MarkId).IsRequired();


        }
    }
}
