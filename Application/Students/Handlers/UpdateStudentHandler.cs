using Application.Common.Interfaces;
using Application.Common.Results;
using Application.Students.Commands;
using Application.Students.Queries;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SMSDomain.Entities;
using SMSDomain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Students.Handlers
{
    public class UpdateStudentHandler : IRequestHandler<UpdateStudentRequestCommand, IDataResult<UpdateStudentRequestCommand>>
    {
        private readonly IApplicationDbContext _dbContext;
        private IMapper _mapper;

        public UpdateStudentHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        //public async Task<IDataResult<UpdateStudentRequestCommand>> Handle(UpdateStudentRequestCommand request, CancellationToken cancellationToken)
        //{
        //    var studentUpdate = await _dbContext.Students.FirstOrDefaultAsync(x => x.Id == request.Id);
        //    if (studentUpdate != null)
        //    {
        //        foreach (var item in request.GetType().GetProperties())
        //        {
        //            var propertyName = item.Name;
        //            var propertyValue = item.GetValue(request);
        //            if (propertyValue == null || propertyValue == "string")
        //            {
        //                propertyValue = 
        //                studentUpdate.GetType().GetProperty(item.Name)
        //                    .GetValue(studentUpdate);


        //            }
        //            else if (studentUpdate.GetType().GetProperty(item.Name)?.PropertyType == typeof(Status?))
        //            {
        //                if (propertyValue is int intValue)
        //                {
        //                    propertyValue = (Status?)intValue;
        //                }

        //            }

        //            // studentUpdate.GetType().GetProperty(propertyName).SetValue(studentUpdate.GetType().GetProperty(propertyName).GetValue(studentUpdate)  , propertyValue);
        //            var studentProperty = studentUpdate.GetType().GetProperty(propertyName);

        //            if (studentProperty != null)
        //            {
        //                studentProperty.SetValue(studentUpdate, propertyValue);
        //            }


        //        }

        //        _dbContext.Students.Update(studentUpdate);
        //        await _dbContext.SaveChangesAsync(cancellationToken);


        //    }
        //    return new SuccessDataResult<UpdateStudentRequestCommand>(request, "Post update successfully");
        //}

        //public async Task<IDataResult<UpdateStudentRequestCommand>> Handle(UpdateStudentRequestCommand request, CancellationToken cancellationToken)
        //{
        //    var studentUpdate = await _dbContext.Students.FirstOrDefaultAsync(x => x.Id == request.Id);

        //    if (studentUpdate != null)
        //    {
        //        var studentType = studentUpdate.GetType();

        //        foreach (var item in request.GetType().GetProperties())
        //        {
        //            var propertyName = item.Name;
        //            var propertyValue = item.GetValue(request);

        //            if (propertyValue != null)
        //            {
        //                var studentProperty = studentType.GetProperty(propertyName);

        //                if (studentProperty != null)
        //                {
        //                    studentProperty.SetValue(studentUpdate, propertyValue);
        //                }
        //            }
        //        }

        //        _dbContext.Students.Update(studentUpdate);
        //        await _dbContext.SaveChangesAsync(cancellationToken);
        //    }

        //    return new SuccessDataResult<UpdateStudentRequestCommand>(request, "Post update successfully");
        //}

       public async Task<IDataResult<UpdateStudentRequestCommand>> Handle(UpdateStudentRequestCommand request, CancellationToken cancellationToken)
        {
            //var StudentById = await _appDbContext.Students.FirstOrDefaultAsync(student => student.Id == request.Id);
            
            var studentUpdate = await _dbContext.Students.FirstOrDefaultAsync(x => x.Id == request.Id);
            //var student = _mapper.Map<UpdateStudentRequestCommand>(studentUpdate);
            var address = await _dbContext.Addresses.FirstOrDefaultAsync( x => x.StudentId == studentUpdate.Id);
            studentUpdate.Address= address;
            if (studentUpdate != null)
            {

                
                studentUpdate.Id = request.Id;
                studentUpdate.Name = request.Name;
                studentUpdate.Surname = request.Surname;
                studentUpdate.Email = request.Email;
                studentUpdate.FathersName  = request.FathersName;
                studentUpdate.Age = request.Age;
                studentUpdate.BirthDate = request.BirthDate;
                studentUpdate.Fin = request.Fin;
                studentUpdate.AverageGrade = request.AverageGrade;
                studentUpdate.Address.District = request.District;
                studentUpdate.Address.StreetAddress = request.StreetAddress;
                studentUpdate.Address.HouseNo = request.HouseNo;
                studentUpdate.Address.ZipCode = request.ZipCode;
                studentUpdate.Address.HomeNumber = request.HomeNumber;
                studentUpdate.CountryId = _dbContext.Countries.FirstOrDefault(c => c.Name == request.Countryname).Id;
                studentUpdate.CityId = _dbContext.Cities.FirstOrDefault(c => c.Name == request.Cityname).Id;
               
                


                var phoneNumbers = new List<PhoneNumber>();
                foreach (var number in request.Phonenumbers)
                {
                   phoneNumbers.Add(new PhoneNumber { Number = number, StudentId = request.Id});
                }
                _dbContext.PhoneNumbers.UpdateRange(phoneNumbers);




                //List < CourseStudent > updateCourses = await _dbContext.CourseStudent.Where(c => c.StudentId == studentUpdate.Id).ToListAsync();
                var courseStudents = new List<CourseStudent>();
                foreach(var course in request.CourseName)
                {
                    var courseId = _dbContext.Courses.FirstOrDefault(c => c.Name == course).Id;
                    courseStudents.Add(new CourseStudent { StudentId = request.Id, CourseId = courseId });
                }
                _dbContext.CourseStudent.UpdateRange(courseStudents);




                var groupStudents = new List<GroupStudent>();
                foreach (var group in request.GroupName)
                {
                    var groupId = _dbContext.Groups.FirstOrDefault(c => c.Name == group).Id;
                    groupStudents.Add(new GroupStudent { StudentId = request.Id, GroupId = groupId });
                }
                _dbContext.GroupStudent.UpdateRange(groupStudents);



                studentUpdate.Status = (Status?)request.Status;

                if (request.Status == 1)
                {
                    studentUpdate.LeftStatus.LeftMessage = request.leftMessage;
                    studentUpdate.LeftStatus.LeftDate = request.LeftDate;
                }
                else if (request.Status == 2)
                {
                    studentUpdate.StoppedStatus.StoppedMessage = request.StoppedMessage;
                    studentUpdate.StoppedStatus.ApproximateStartDate = request.ApproximateStartDate;
                    studentUpdate.StoppedStatus.StoppedDate = request.StoppedDate;

                }
                else if (request.Status == 3)
                {
                    studentUpdate.GraduatedStatus.GraduatedDate = request.GraduatedDate;
                }


                await _dbContext.SaveChangesAsync(cancellationToken);
            }

            return new SuccessDataResult<UpdateStudentRequestCommand>(request, "Post update successfully");
        }
    }
}
