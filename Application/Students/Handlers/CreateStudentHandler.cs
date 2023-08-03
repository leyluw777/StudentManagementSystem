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
        private readonly UserManager<AppUser> _userManager;

        public CreateStudentHandler(IApplicationDbContext appDbContext, IMapper mapper, UserManager<AppUser> userManager)
        {
            _appDbContext = appDbContext;
            _mapper = mapper;
            _userManager = userManager;
        }

        public string GenerateUniqueUsername(CreateStudentRequestCommand request)
        {

            var username = request.Name + request.FathersName[0] + request.Surname[0]+ request.Fin;
            return username;
        }
        public string GenerateRandomPassword()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var random = new Random();

            var password = new char[10];
            for (int i = 0; i < password.Length; i++)
            {
                password[i] = chars[random.Next(chars.Length)];
            }
            return new string(password);
        }

        public async Task<CreateStudentResponseCommand> Handle(CreateStudentRequestCommand request, CancellationToken cancellationToken)
        {
                
            string username = GenerateUniqueUsername(request);
            string password = GenerateRandomPassword();
            if (await _userManager.Users.AnyAsync(student => student.Fin == request.Fin))
            {
                throw new Exception("A user with the same FIN already exists.");
               
            }
            else
            {
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
                    
                };
                Address studentAddress = new Address()
                {
                    StudentId = newStudent.Id,
                    District = request.District,
                    StreetAddress = request.StreetAddress,
                    ZipCode = request.ZipCode,
                    HomeNumber = request.HomeNumber,
                };
                Country studentCountry = new Country()
                {
                    StudentId = newStudent.Id,
                    Name = request.Countryname
                };
                City studentCity = new City()
                {
                    StudentId = newStudent.Id,
                    Name = request.Cityname
                };
                PhoneNumber studentNumber = new PhoneNumber()
                {
                    StudentId = newStudent.Id,
                    Number = request.Phonenumber
                };
                NumberPrefix studentNumberPrefix = new NumberPrefix()
                {
                    PhoneNumberId = studentNumber.Id,
                    Prefix = request.NumberPrefix
                };
                foreach(var course in request.Courses)
                {
                   
                }
               // qaldi kurs i qrup, qalani normal iwleyir 
                //Student newStudent = _mapper.Map<Student>(request);

                await _appDbContext.Students.AddAsync(newStudent);
                await _appDbContext.Addresses.AddAsync(studentAddress);
                await _appDbContext.Countries.AddAsync(studentCountry);
                await _appDbContext.Cities.AddAsync(studentCity);
               // await _appDbContext.Students.AddAsync(newStudent);
                await _appDbContext.SaveChangesAsync(cancellationToken);

                return new CreateStudentResponseCommand()
                {
                    Username = username,
                    Password = password,
                    Id = Guid.NewGuid(),
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
