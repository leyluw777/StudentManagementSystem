using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Configurations
{
    public class PhoneNumberConfiguration : IEntityTypeConfiguration<PhoneNumber>
    {
        public void Configure(EntityTypeBuilder<PhoneNumber> builder)
        {
            builder.ConfigureAuditableBaseEntity<PhoneNumber>();
            builder.Property(x => x.Number).IsRequired();
            builder.Property(x => x.Student).IsRequired();
            builder.Property(x => x.Teacher).IsRequired();
            builder.Property(x => x.Coordinator).IsRequired();
        
            builder.HasOne(x=>x.Student).WithMany(x=>x.PhoneNumbers)
                .HasForeignKey(x=>x.StudentId).IsRequired();

            builder.HasOne(x => x.Teacher).WithMany(x => x.PhoneNumbers)
                .HasForeignKey(x => x.TeacherId).IsRequired();

            builder.HasOne(x => x.Coordinator).WithMany(x => x.PhoneNumbers)
                .HasForeignKey(x => x.CoordinatorId).IsRequired();


        }
    }
}
