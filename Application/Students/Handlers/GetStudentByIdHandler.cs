using Application.Common.Interfaces;
using Application.Students.Queries;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SMSDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Students.Handlers
{
    public class GetStudentByIdHandler : IRequestHandler<GetStudentByIdQueryRequest, GetStudentByIdQueryResponse>
    {
        private readonly IApplicationDbContext _appDbContext;
        private readonly IMapper _mapper;

        public GetStudentByIdHandler(IApplicationDbContext appDbContext, IMapper mapper)
        {
            _appDbContext = appDbContext;
            _mapper = mapper;
        }

        public async Task<GetStudentByIdQueryResponse> Handle(GetStudentByIdQueryRequest request, CancellationToken cancellationToken)
        {
            
            var StudentById = await _appDbContext.Students
    .Include(s => s.Address)
    .Include(s => s.Country)
    .Include(s => s.City).FirstOrDefaultAsync(student => student.Id == request.Id);
            //var student = _mapper.Map<GetStudentByIdQueryResponse>(StudentById);

            GetStudentByIdQueryResponse student = new GetStudentByIdQueryResponse()
            {
                Id = StudentById.Id,
                Name = StudentById.Name,
                Surname = StudentById.Surname,
                Email = StudentById.Email,
                FathersName = StudentById.FathersName,
                Age = StudentById.Age,
                BirthDate = StudentById.BirthDate,
                Gender = StudentById.Gender,
                Image = StudentById.Image,
                Fin = StudentById.Fin,
                AverageGrade = StudentById.AverageGrade,
                Address = StudentById.Address != null   
        ? StudentById.Address.District + ' ' + StudentById.Address.StreetAddress + ' ' + StudentById.Address.HouseNo.ToString()
        : string.Empty,
                Country = StudentById.Country != null ? StudentById.Country.Name : string.Empty,
                City = StudentById.City != null ? StudentById.City.Name : string.Empty


            };

        student.Courses = new List<string>();
            var courseStudent = await _appDbContext.CourseStudent.Where(cs => cs.StudentId == request.Id).ToListAsync();
            foreach (var item in courseStudent)
            {
                var course = await _appDbContext.Courses.FirstOrDefaultAsync(c => c.Id == item.CourseId);
                student.Courses.Add(course.Name);
            }


            student.Groups = new List<string>();
            var groupStudent = await _appDbContext.GroupStudent.Where(cs => cs.StudentId == request.Id).ToListAsync();
            foreach (var item in groupStudent)
            {
                var group = await _appDbContext.Groups.FirstOrDefaultAsync(c => c.Id == item.GroupId);
                student.Groups.Add(group.Name);
            }

            student.PhoneNumbers = new List<string>();
            var numberStudent = await _appDbContext.PhoneNumbers.Where(cs => cs.StudentId == request.Id).ToListAsync();
            foreach (var item in numberStudent)
            {
                
                    student.PhoneNumbers.Add( item.Number);
                
            }


            //student.Courses = new List<Course>();
            //var courseStudent = await _appDbContext.CourseStudent.Where(cs => cs.StudentId == request.Id).ToListAsync();
            //foreach (var item in courseStudent)
            //{
            //    var course = await _appDbContext.Courses.FirstOrDefaultAsync(c => c.Id == item.CourseId);
            //    student.Courses.Add(course);
            //}
            return student;

        }
    }
}
