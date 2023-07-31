

namespace Infrastructure.Persistence.Configurations
{
    public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.ConfigureAuditableBaseEntity();
            //builder.Property(c => c.Student).IsRequired();
            builder.Property(c => c.StreetAddress).IsRequired();
            builder.Property(c => c.Country).IsRequired();
            builder.Property(c => c.District).IsRequired();
            builder.Property(c => c.City).IsRequired();
            builder.Property(c => c.HouseNo).IsRequired();
            builder.Property(c => c.ZipCode).IsRequired();
            builder.Property(c => c.HomeNumber).IsRequired();
            //builder.Property(c => c.Teacher).IsRequired();



            //builder.HasOne(h => h.Student)
            //       .WithOne(h => h.Address)
            //       .HasForeignKey<Address>(x => x.StudentId)
            //       .IsRequired(true);

            //builder.HasOne(h => h.Teacher)
            //      .WithOne(h => h.Address)
            //      .HasForeignKey<Address>(x => x.TeacherId)
            //      .IsRequired(true);

            builder.HasOne(h => h.Coordinator)
               .WithOne(h => h.Address)
               .HasForeignKey<Address>(x => x.CoordinatorId)
               .IsRequired(true);

            builder.HasOne(h => h.Country)  //burda
               .WithMany(x => x.Address)
               .HasForeignKey(h => h.CountryId)
               .IsRequired(true);


            builder.HasOne(h => h.City)
               .WithMany(x => x.Addresses)
               .HasForeignKey(h => h.CityId)
               .IsRequired(true);
        }
    }
}
