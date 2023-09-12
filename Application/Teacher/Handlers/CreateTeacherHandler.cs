using Application.Common.Interfaces;
using Application.Common.Results;
using Application.Teacher.Commands;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SMSDomain.Entities;
using SMSDomain.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Teacher.Handlers
{
	public class CreateTeacherHandler : IRequestHandler<CreateTeacherRequestCommand, CreateTeacherResponseCommand>
	{
		private readonly IApplicationDbContext _appDbContext;
		private readonly IMapper _mapper;
		private readonly UserManager<SMSDomain.Identity.AppUser> _userManager;
		private readonly RoleManager<AppRole> _roleManager;

		public CreateTeacherHandler(IApplicationDbContext appDbContext, IMapper mapper, UserManager<SMSDomain.Identity.AppUser> userManager, RoleManager<AppRole> roleManager)
		{
			_appDbContext = appDbContext;
			_mapper = mapper;
			_userManager = userManager;
			_roleManager = roleManager;
		}

		public string GenerateUniqueUsername(CreateTeacherRequestCommand request)
		{

			var username = request.Name.ToLower() + request.FathersName[0] + request.Surname[0] + request.Fin;
			return username;
		}
		public string GenerateRandomPassword()
		{
			const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
			var random = new Random();

			var password = new char[10];
			for (int i = 0; i < password.Length - 1; i++)
			{
				password[i] = chars[random.Next(chars.Length)];
			}
			password[9] = '!';
			return new string(password);
		}

		public async Task<CreateTeacherResponseCommand> Handle(CreateTeacherRequestCommand request, CancellationToken cancellationToken)
		{

			string username = GenerateUniqueUsername(request);
			string password = GenerateRandomPassword();
			if (await _userManager.Users.AnyAsync(teacher => teacher.Fin == request.Fin))
			{
				throw new Exception("A user with the same FIN already exists.");
			}
			else
			//wtf. doldur
			{
				//var studentCity = _appDbContext.Cities.Include(x => x.Id).FirstOrDefaultAsync(c => c.Name == request.Cityname); 
				SMSDomain.Entities.Teacher newTeacher = new SMSDomain.Entities.Teacher()
				{
					Name = request.Name,
					Surname = request.Surname,
					FathersName = request.FathersName,
					Email = request.Email,
					Age = request.Age,
					Gender = request.Gender,
					Fin = request.Fin,
					Description = request.Description,
					ActiveStatus = (bool)request.ActiveStatus,
					Experience = request.Experience,
					UserName = username,
					BirthDate = request.BirthDate
				};
				//await _appDbContext.Students.AddAsync(newStudent);
				//await _appDbContext.SaveChangesAsync(cancellationToken); yatarsan
				var a = await _userManager.CreateAsync(newTeacher, password);


				// en evvelden butun userler mende netusers table in de save olunurdu, men qaldim ki nece ayirim
				// teacher studentleri, ona gore onlari ayri bir table a cixartdim, ve her role un 
				// specific propertyleri orda saxlanilir
				await _userManager.AddToRoleAsync(newTeacher, "Teacher");


				FirstLogin firstLogin = new()
				{
					UserId = newTeacher.Id,
					UserName = newTeacher.UserName,
					Password = password,
					Name = newTeacher.Name,
					Surname = newTeacher.Surname,
					FathersName = newTeacher.FathersName
				};

				await _appDbContext.FirstLogins.AddAsync(firstLogin);
				//await _userManager.AddPasswordAsync(newStudent, password);





				Address teacherAddress = new Address()
				{
					TeacherId = newTeacher.Id,
					District = request.District,
					StreetAddress = request.StreetAddress,
					ZipCode = request.ZipCode,
					HomeNumber = request.HomeNumber,
					HouseNo = request.HouseNo,
				};
				await _appDbContext.Addresses.AddAsync(teacherAddress);



				var phoneNumbers = new List<PhoneNumber>();
				foreach (var number in request.PhoneNumbers)
				{

					phoneNumbers.Add(new PhoneNumber { Number = number, TeacherId = newTeacher.Id });
				}
				await _appDbContext.PhoneNumbers.AddRangeAsync(phoneNumbers);
				//	await _appDbContext.SaveChangesAsync(cancellationToken);


				//   await _appDbContext.NumberPrefixes.AddAsync(studentNumberPrefix);
				//await _appDbContext.SaveChangesAsync(cancellationToken);

				List<CourseTeacher> courseTeachers = new List<CourseTeacher>();
				List<Course> courses = await _appDbContext.Courses.Where(c => c.Name == request.Course).ToListAsync();
				foreach (var course in courses)
				{
					CourseTeacher teacherCourse = new CourseTeacher()
					{
						TeacherId = newTeacher.Id,
						CourseId = course.Id

					};
					courseTeachers.Add(teacherCourse);
				}
				await _appDbContext.CourseTeacher.AddRangeAsync(courseTeachers);

				//umumiyyetke duwmedi e

				try
				{
					List<GroupTeacher> teacherGroups = new();
					List<Group> groups = await _appDbContext.Groups.Where(c => c.Name == request.Group).ToListAsync();
					foreach (var group in groups)
					{
						GroupTeacher teacherGroup = new GroupTeacher()
						{
							TeacherId = newTeacher.Id,
							GroupId = group.Id

						};
						teacherGroups.Add(teacherGroup);
					}


					await _appDbContext.GroupTeacher.AddRangeAsync(teacherGroups);
					await _appDbContext.SaveChangesAsync(cancellationToken);
				}
				catch (Exception ex)
				{
					Console.WriteLine(ex.Message);
				}



				return new CreateTeacherResponseCommand()
				{
					Username = username,
					Password = password,
					Id = newTeacher.Id

				};

			}
		}

	}


}

