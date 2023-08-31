using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.SeedData
{
    public static class GroupsSeedData
    {
        public static void AddGroupsData(this ModelBuilder builder)
        {
            builder.Entity<Group>().HasData(
                new Group
                {
                    Id = 2,
                    Name = "BACK100",
                },
                new Group
                {
                    Id = 3,
                    Name = "MOBILE95",
                },
                new Group
                {
                    Id = 4,
                    Name = "CYBER220",
                }
                );
        }
    }
}
