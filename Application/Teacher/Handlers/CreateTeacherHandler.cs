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
                //await _appDbContext.SaveChangesAsync(cancellationToken);
                var a = await _userManager.CreateAsync(newTeacher, password);

                await _userManager.AddToRoleAsync(newTeacher, "Teacher");



                FirstLogin firstLogin = new()
                {
                    UserId = newTeacher.Id,
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
                await _appDbContext.SaveChangesAsync(cancellationToken);


                //City studentCity = new City()
                //{
                //    StudentId = newStudent.Id,
                //    Name = request.Cityname
                //};

                //['050', '070', '055']
                //['03434343450', '073434340', '0553434434343']

                var phoneNumbers = new List<PhoneNumber>();
                foreach (var number in request.PhoneNumbers)
                {

                    phoneNumbers.Add(new PhoneNumber { Number = number, TeacherId = newTeacher.Id });
                }
                await _appDbContext.PhoneNumbers.AddRangeAsync(phoneNumbers);

                await _appDbContext.SaveChangesAsync(cancellationToken);

                //   await _appDbContext.NumberPrefixes.AddAsync(studentNumberPrefix);
                await _appDbContext.SaveChangesAsync(cancellationToken);


                List<Course> courses = await _appDbContext.Courses.Where(c => c.Name == request.Course).ToListAsync();
                foreach (var course in courses)
                {
                    CourseTeacher teacherCourse = new CourseTeacher()
                    {
                        TeacherId = newTeacher.Id,
                        CourseId = course.Id

                    };
                    await _appDbContext.CourseTeacher.AddAsync(teacherCourse);
                    await _appDbContext.SaveChangesAsync(cancellationToken);
              }

                await _appDbContext.SaveChangesAsync(cancellationToken);


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

