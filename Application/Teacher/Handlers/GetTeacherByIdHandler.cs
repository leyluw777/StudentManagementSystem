using Application.Common.Interfaces;
using Application.Teacher.Queries;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SMSDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Teacher.Handlers
{
    public class GetTeacherByIdHandler : IRequestHandler<GetTeacherByIdQueryRequest, GetTeacherByIdQueryResponse>
    {
        private readonly IApplicationDbContext _appDbContext;
        private readonly IMapper _mapper;

        public GetTeacherByIdHandler(IApplicationDbContext appDbContext, IMapper mapper)
        {
            _appDbContext = appDbContext;
            _mapper = mapper;
        }


        public async Task<GetTeacherByIdQueryResponse> Handle(GetTeacherByIdQueryRequest request, CancellationToken cancellationToken)
        {

            var TeacherById = await _appDbContext.Teachers
    
                   .FirstOrDefaultAsync(teacher => teacher.Id == request.Id);
            //var teacher = _mapper.Map<GetTeacherByIdQueryResponse>(TeacherById);

            GetTeacherByIdQueryResponse teacher = new GetTeacherByIdQueryResponse()
            {
                Id = TeacherById.Id,
                Name = TeacherById.Name,
                Surname = TeacherById.Surname,
                Email = TeacherById.Email,
                FathersName = TeacherById.FathersName,
                Age = TeacherById.Age,
                BirthDate = TeacherById.BirthDate,
                Gender = TeacherById.Gender,
                Fin = TeacherById.Fin,
                Description = TeacherById.Description,
                ActiveStatus = TeacherById.ActiveStatus,
                Experience = TeacherById.Experience,
                
                Address = TeacherById.Address != null
        ? TeacherById.Address.District + ' ' + TeacherById.Address.StreetAddress + ' ' + TeacherById.Address.HouseNo.ToString()
        : string.Empty,
              
            };

            teacher.Courses = new List<string>();
            var courseteacher = await _appDbContext.CourseTeacher.Where(cs => cs.TeacherId == request.Id).ToListAsync();
            foreach (var item in courseteacher)
            {
                var course = await _appDbContext.Courses.FirstOrDefaultAsync(c => c.Id == item.CourseId);
                teacher.Courses.Add(course.Name);
            }


            teacher.PhoneNumbers = new List<string>();
            var numberteacher = await _appDbContext.PhoneNumbers.Where(cs => cs.TeacherId == request.Id).ToListAsync();
            foreach (var item in numberteacher)
            {

                teacher.PhoneNumbers.Add(item.Number);

            }


            //teacher.Courses = new List<Course>();
            //var courseteacher = await _appDbContext.Courseteacher.Where(cs => cs.teacherId == request.Id).ToListAsync();
            //foreach (var item in courseteacher)
            //{
            //    var course = await _appDbContext.Courses.FirstOrDefaultAsync(c => c.Id == item.CourseId);
            //    teacher.Courses.Add(course);
            //}
            return teacher;

        }


    }
}
