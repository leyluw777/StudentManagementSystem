using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Configurations
{
    public class TeacherConfiguration : IEntityTypeConfiguration<Teacher>
    {
        public void Configure(EntityTypeBuilder<Teacher> builder)
        {
            builder.Property(x => x.Description).IsRequired(false);
            builder.Property(x => x.Experience).IsRequired(false);
            builder.Property(x => x.ActiveStatus).IsRequired();
            //builder.Property(x => x.Address).IsRequired();
            //builder.Property(x => x.PhoneNumbers).IsRequired();
            //builder.Property(x => x.Courses).IsRequired();
        }
    }
}
