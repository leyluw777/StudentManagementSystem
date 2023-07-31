using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Configurations
{
    public class LessonConfiguration : IEntityTypeConfiguration<Lesson>
    {
        public void Configure(EntityTypeBuilder<Lesson> builder)
        {
            builder.ConfigureAuditableBaseEntity<Lesson>();
            builder.Property(x => x.Module).IsRequired();
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.TopicsCovered).IsRequired(false);
            builder.Property(x => x.Notes).IsRequired(false);
            builder.Property(x => x.LessonDate).IsRequired();
            
        }
    }
}
