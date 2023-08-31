using Application.Common.Interfaces;
using Application.Common.Results;
using Application.Students.Commands;
using Application.Teacher.Commands;
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
    public class UpdateTeacherHandler : IRequestHandler<UpdateTeacherRequestCommand, IDataResult<UpdateTeacherRequestCommand>>
    {
        private readonly IApplicationDbContext _dbContext;
        private IMapper _mapper;

        public UpdateTeacherHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<IDataResult<UpdateTeacherRequestCommand>> Handle(UpdateTeacherRequestCommand request, CancellationToken cancellationToken)
        {
            var teacherUpdate = await _dbContext.Teachers.FirstOrDefaultAsync(x => x.Id == request.Id);
            //var student = _mapper.Map<UpdateStudentRequestCommand>(studentUpdate);
            var address = await _dbContext.Addresses.FirstOrDefaultAsync(x => x.TeacherId == teacherUpdate.Id);
            teacherUpdate.Address = address;
            if (teacherUpdate != null)
            {

                teacherUpdate.Id = request.Id;
                teacherUpdate.Name = request.Name;
                teacherUpdate.Surname = request.Surname;
                teacherUpdate.Email = request.Email;
                teacherUpdate.FathersName = request.FathersName;
                teacherUpdate.Age = request.Age;
            
                teacherUpdate.Fin = request.Fin;
               
                teacherUpdate.Address.District = request.District;
                teacherUpdate.Address.StreetAddress = request.StreetAddress;
                teacherUpdate.Address.HouseNo = request.HouseNo;
                teacherUpdate.Address.ZipCode = request.ZipCode;
                teacherUpdate.Address.HomeNumber = request.HomeNumber;
                teacherUpdate.Description = request.Description;
                teacherUpdate.ActiveStatus = (bool)request.ActiveStatus;
                teacherUpdate.Experience = request.Experience;



                //List < CourseStudent > updateCourses = await _dbContext.CourseStudent.Where(c => c.StudentId == studentUpdate.Id).ToListAsync();
                var courseTeachers = new List<CourseTeacher>();
                foreach (var course in request.Courses)
                {
                    var courseId = _dbContext.Courses.FirstOrDefault(c => c.Name == course).Id;
                    courseTeachers.Add(new CourseTeacher { TeacherId = request.Id, CourseId = courseId });
                }
                _dbContext.CourseTeacher.UpdateRange(courseTeachers);



                var phoneNumbers = new List<PhoneNumber>();



                foreach (var number in request.PhoneNumbers)
                {
                    phoneNumbers.Add(new PhoneNumber { Number = number, TeacherId = request.Id });
                }
                _dbContext.PhoneNumbers.UpdateRange(phoneNumbers);


                await _dbContext.SaveChangesAsync(cancellationToken);


                return new SuccessDataResult<UpdateTeacherRequestCommand>(request, "Post update successfully");

            }





            throw new NotImplementedException();
        }
    }
}
