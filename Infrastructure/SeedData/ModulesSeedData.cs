using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.SeedData
{
	public static class ModulesSeedData
	{
		public static void AddModulesData(this ModelBuilder builder)
		{
			builder.Entity<Module>().HasData(
				new Module
				{
					Id = 1,
					Name = "Basics",
					CourseId = 1,
					TotalHours = 70
				},
				new Module
				{
					Id = 2,
					Name = "Introduction to programming",
					CourseId = 1,
					TotalHours = 70
				},
				new Module
				{
					Id = 3,
					Name = "ReactJS",
					CourseId = 1,
					TotalHours = 70
				},
				new Module
				{
					Id = 4,
					Name = "API",
					CourseId = 1,
					TotalHours = 70
				},
				new Module
				{
					Id = 5,
					Name = "Basics",
					CourseId = 2,
					TotalHours = 50
				},
				new Module
				{
					Id = 6,
					Name = "OOP",
					CourseId = 2,
					TotalHours = 100
				},
				new Module
				{
					Id = 7,
					Name = "Databases",
					CourseId = 2,
					TotalHours = 100
				},
				new Module
				{
					Id = 8,
					Name = "Web application",
					CourseId = 2,
					TotalHours = 100
				},
					new Module
					{
						Id = 9,
						Name = "Introduction",
						CourseId = 3,
						TotalHours = 50
					},
					new Module
					{
						Id = 10,
						Name = "Statistical and math skills",
						CourseId = 3,
						TotalHours = 50
					},
					new Module
					{
						Id = 11,
						Name = "Data visualization",
						CourseId = 3,
						TotalHours = 50
					},
					new Module
					{
						Id = 12,
						Name = "Databases",
						CourseId = 3,
						TotalHours = 100
					},
					new Module
					{
						Id = 13,
						Name = "Fundamentals",
						CourseId = 4,
						TotalHours = 50
					},
					new Module
					{
						Id = 14,
						Name = "UX Design concepts",
						CourseId = 4,
						TotalHours = 70
					},
					new Module
					{
						Id = 15,
						Name = "Wireframing",
						CourseId = 4,
						TotalHours = 100
					},
					new Module
					{
						Id = 16,
						Name = "The Business of UX & UI Design",
						CourseId = 4,
						TotalHours = 100
					},
						new Module
						{
							Id = 17,
							Name = "Foundation of Computing and Cyber Security",
							CourseId = 5,
							TotalHours = 100
						},
						new Module
						{
							Id = 18,
							Name = "Endpoint Security",
							CourseId = 5,
							TotalHours = 100
						},
						new Module
						{
							Id = 19,
							Name = "Secure Coding",
							CourseId = 5,
							TotalHours = 170
						},
						new Module
						{
							Id = 20,
							Name = "Business Infrastructure and Security",
							CourseId = 5,
							TotalHours = 100
						},
						new Module
						{
							Id = 21,
							Name = "Introduction",
							CourseId = 6,
							TotalHours = 50
						},
						new Module
						{
							Id = 22,
							Name = "UI of apps",
							CourseId = 6,
							TotalHours = 100
						},
						new Module
						{
							Id = 23,
							Name = "Databases",
							CourseId = 6,
							TotalHours = 60
						},
						new Module
						{
							Id = 24,
							Name = "Security",
							CourseId = 6,
							TotalHours = 90
						}
				);


		}
	}
}
