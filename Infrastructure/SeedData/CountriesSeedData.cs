using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.SeedData
{
    public static class CountriesSeedData
    {
        public static void AddCountriesData(this ModelBuilder builder)
        {
            builder.Entity<Country>().HasData(
                new Country { Id = 1, Name =  "Azerbaijan" },
                 new Country { Id = 2, Name = "Georgia" },
                 new Country { Id = 3, Name = "Israel" },
                 new Country { Id = 4, Name = "Kazakhstan" },
                 new Country { Id = 5, Name = "Russia" },
                 new Country { Id = 6, Name = "Tajikistan" },
                 new Country { Id = 7, Name = "Turkey" },
                 new Country { Id = 8, Name = "Turkmenistan" },
                 new Country { Id = 9, Name = "Ukraine" },
                 new Country { Id = 10, Name = "Uzbekistan" }


                );
        }
    }
}
