using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Configurations
{
    public class CountryConfiguration : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.ConfigureAuditableBaseEntity<Country>();
            builder.Property(x => x .Name).IsRequired();    
            builder.Property(x => x .Address).IsRequired();    
            builder.Property(x => x .Cities).IsRequired();    
        }
    }
}
