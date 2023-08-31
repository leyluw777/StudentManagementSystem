using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.SeedData
{
	public static class CoursesSeedData
	{
		public static void AddCoursesData(this ModelBuilder builder)
		{
			builder.Entity<Course>().HasData(
				new Course
				{
					Id = 1,
					Name = "Front-end development",
					TotalModules = 4,
					TotalHours = 280,
				},
				new Course
				{
					Id = 2,
					Name = "Back-end development",
					TotalModules = 4,
					TotalHours = 350,
				},


				new Course
				{
					Id = 3,
					Name = "Data science",
					TotalModules = 4,
					TotalHours = 250,
				},
				new Course
				{
					Id = 4,
					Name = "UI/UX design",
					TotalModules = 4,
					TotalHours = 320,
				},
				new Course
				{
					Id = 5,
					Name = "Cybersecurity",
					TotalModules = 4,
					TotalHours = 370,
				},
				new Course
				{
					Id = 6,
					Name = "Mobile development",
					TotalModules = 4,
					TotalHours = 300,
				}
				);
		}
	}
}
