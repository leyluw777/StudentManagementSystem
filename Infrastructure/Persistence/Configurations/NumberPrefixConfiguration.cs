using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Configurations
{
    public class NumberPrefixConfiguration : IEntityTypeConfiguration<NumberPrefix>
    {
        public void Configure(EntityTypeBuilder<NumberPrefix> builder)
        {
            builder.ConfigureAuditableBaseEntity<NumberPrefix>();
            builder.Property(x => x.PhoneNumber).IsRequired();
            builder.Property(x => x.Prefix).IsRequired();

            builder.HasOne(x=>x.PhoneNumber).WithMany(x=>x.NumberPrefixes)
                .HasForeignKey(x=>x.PhoneNumberId).IsRequired();
        }
    }
}
