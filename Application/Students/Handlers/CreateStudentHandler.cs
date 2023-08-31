using Application.Common.Interfaces;
using Application.Common.Mappings;
using Application.Common.Results;
using Application.Students.Commands;
using AutoMapper;
using MediatR;
using MediatR.Pipeline;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using SMSDomain.Entities;
using SMSDomain.Identity;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Students.Handlers
{
    public class CreateStudentHandler : IRequestHandler<CreateStudentRequestCommand, CreateStudentResponseCommand>
    {
        private readonly IApplicationDbContext _appDbContext;
        private readonly IMapper _mapper;
        private readonly UserManager<SMSDomain.Identity.AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;

        public CreateStudentHandler(IApplicationDbContext appDbContext, IMapper mapper, UserManager<SMSDomain.Identity.AppUser> userManager, RoleManager<AppRole> roleManager)
        {
            _appDbContext = appDbContext;
            _mapper = mapper;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public string GenerateUniqueUsername(CreateStudentRequestCommand request)
        {

            var username = request.Name.ToLower() + request.FathersName[0] + request.Surname[0]+ request.Fin;
            return username;
        }
        public string GenerateRandomPassword()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var random = new Random();

            var password = new char[10];
            for (int i = 0; i < password.Length-1; i++)
            {
                password[i] = chars[random.Next(chars.Length)];
            }
            password[9] = '!';
            return new string(password);
        }

        public async Task<CreateStudentResponseCommand> Handle(CreateStudentRequestCommand request, CancellationToken cancellationToken)
        {
                
            string username =  GenerateUniqueUsername(request);
            string password = GenerateRandomPassword();
            if (await _userManager.Users.AnyAsync(student => student.Fin == request.Fin))
            {
                throw new Exception("A user with the same FIN already exists.");

            }
            else
            {
                //var studentCity = _appDbContext.Cities.Include(x => x.Id).FirstOrDefaultAsync(c => c.Name == request.Cityname); 
                Student newStudent = new Student()
                {
                    Name = request.Name,
                    Surname = request.Surname,
                    FathersName = request.FathersName,
                    Email = request.Email,
                    Age = request.Age,
                    BirthDate = request.BirthDate,
                    Gender = request.Gender,
                    Fin = request.Fin,
                    Status = (SMSDomain.Enums.Status)request.Status,
                    CityId = _appDbContext.Cities.FirstOrDefault(x => x.Name == request.City).Id,
                    CountryId =  _appDbContext.Countries.FirstOrDefault(c => c.Name == request.Country).Id,
                    AverageGrade = 0.0,
                    UserName = username,
                  
                };
                //await _appDbContext.Students.AddAsync(newStudent);
                //await _appDbContext.SaveChangesAsync(cancellationToken);
                 var a = await _userManager.CreateAsync(newStudent, password);

                await _userManager.AddToRoleAsync(newStudent, "Student");



                FirstLogin firstLogin = new()
                {
                    UserId = newStudent.Id,
                    UserName = newStudent.UserName,
                    Password = password,
                    Name = newStudent.Name,
                    Surname = newStudent.Surname,
                    FathersName = newStudent.FathersName
                };

                await _appDbContext.FirstLogins.AddAsync(firstLogin);
                //await _userManager.AddPasswordAsync(newStudent, password);





                Address studentAddress = new Address()
                {
                    StudentId = newStudent.Id,
                    District = request.District,
                    StreetAddress = request.StreetAddress,
                    ZipCode = request.ZipCode,
                    HomeNumber = request.HomeNumber,
                    HouseNo = request.HouseNo,
                };
                await _appDbContext.Addresses.AddAsync(studentAddress);
                await _appDbContext.SaveChangesAsync(cancellationToken);


                //City studentCity = new City()
                //{
                //    StudentId = newStudent.Id,
                //    Name = request.Cityname
                //};
           
                //['050', '070', '055']
                //['03434343450', '073434340', '0553434434343']

                var phoneNumbers = new List<PhoneNumber>();
                foreach (var number in request.Phonenumber)
                {
                  
                    phoneNumbers.Add(new PhoneNumber { Number = number, StudentId = newStudent.Id }) ;
                }
               await _appDbContext.PhoneNumbers.AddRangeAsync(phoneNumbers);

                await _appDbContext.SaveChangesAsync(cancellationToken);

             //   await _appDbContext.NumberPrefixes.AddAsync(studentNumberPrefix);
                await _appDbContext.SaveChangesAsync(cancellationToken);


                List<Course> courses = await _appDbContext.Courses.Where(c => c.Name == request.Course).ToListAsync();
                foreach(var course in courses)
                {
                    CourseStudent studentCourse = new CourseStudent()
                    {
                        StudentId = newStudent.Id,
                        CourseId = course.Id

                    };



                    await _appDbContext.CourseStudent.AddAsync(studentCourse);
                    await _appDbContext.SaveChangesAsync(cancellationToken);


                }


                List<Group> groups = await _appDbContext.Groups.Where(c => c.Name == request.Group).ToListAsync();
                foreach (var group in groups)
                {
                    GroupStudent studentGroup = new GroupStudent()
                    {
                        StudentId = newStudent.Id,
                        GroupId = group.Id

                    };



                    await _appDbContext.GroupStudent.AddAsync(studentGroup);
                    await _appDbContext.SaveChangesAsync(cancellationToken);


                }

                //Student newStudent = _mapper.Map<Student>(request);


                //await _appDbContext.Countries.AddAsync(studentCountry);
                //await _appDbContext.Cities.AddAsync(studentCity);

                //await _appDbContext.Courses.AddAsync(courseStudent);
                await _appDbContext.SaveChangesAsync(cancellationToken);

                return new CreateStudentResponseCommand()
                {
                    Username = username,
                    Password = password,
                    Id = newStudent.Id,
                    // DataResult = SuccessDataResult<CreateStudentRequestCommand>(request, "New student added successfully")
                };
            }
        
        }
        private SuccessDataResult<T> SuccessDataResult<T>(T request, string v)
        {
            throw new NotImplementedException();
        }

       
    }
}
