using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Configurations
{
    public class CityConfiguration : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.ConfigureAuditableBaseEntity<City>();
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Country).IsRequired();
            builder.Property(x => x.Addresses).IsRequired();

            builder.HasOne(x => x.Country)
                .WithMany(h => h.Cities)
                .HasForeignKey(x => x.CountryId)
                .IsRequired();

        }


    }
}
