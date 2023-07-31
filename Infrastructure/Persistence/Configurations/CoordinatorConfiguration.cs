using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Configurations
{
    public class CoordinatorConfiguration : IEntityTypeConfiguration<Coordinator>
    {
        public void Configure(EntityTypeBuilder<Coordinator> builder)
        {
            builder.Property(x => x.Courses).IsRequired();  
            builder.Property(x => x.Address).IsRequired();
            builder.Property(x => x.ActiveStatus).IsRequired();
            builder.Property(x => x.PhoneNumbers).IsRequired();


            builder.HasOne(x => x.Address)
                .WithOne(h => h.Coordinator)
                .HasForeignKey<Coordinator>(x => x.AddressId)
                .IsRequired();
                }
    }
}
