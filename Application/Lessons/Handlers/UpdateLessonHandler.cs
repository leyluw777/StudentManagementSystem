using Application.Common.Interfaces;
using Application.Common.Results;
using Application.Lessons.Commands;
using Application.Students.Commands;
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

namespace Application.Lessons.Handlers
{
    public class UpdateLessonHandler : IRequestHandler<UpdateLessonRequestCommand, IDataResult<UpdateLessonRequestCommand>>
    {
        private readonly IApplicationDbContext _dbContext;
        private IMapper _mapper;

        public UpdateLessonHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<IDataResult<UpdateLessonRequestCommand>> Handle(UpdateLessonRequestCommand request, CancellationToken cancellationToken)
        {
            var updatedLesson = _dbContext.Lessons.Include(x => x.Attendances).FirstOrDefault(x => x.Id == request.Id);
            //var groupId = _dbContext.Groups.FirstOrDefault(x => x.Name == request.Group)?.Id;
            //var groupStudents = _dbContext.GroupStudent.Where(x => x.GroupId == groupId).ToList();
            
            var lessons = await  _dbContext.Attendances.Include(x => x.Student).Include(x => x.Lesson).Where(x => x.LessonId == request.Id).AsNoTracking().ToListAsync();
            //request.Attendances = await _dbContext.Attendances.Include(x => x.Student).AsNoTracking().Include(x => x.Lesson).AsNoTracking().Where(x => x.LessonId == request.Id).ToListAsync();
            
            foreach ( var lesson in lessons )
            {

                var reqAttend = request.Attendances.FirstOrDefault(x => x.StudentId == lesson.StudentId && x.LessonId == lesson.LessonId);
                if (reqAttend != null)
                {
                    lesson.Status = reqAttend.Status;
                }
            }
            
            if (updatedLesson != null)
            {

                updatedLesson.Id = request.Id;
                updatedLesson.Name = request.Name;
                updatedLesson.ModuleId = request.Module;
                updatedLesson.GroupId = _dbContext.Groups.FirstOrDefault(x => x.Name == request.Group).Id;
                updatedLesson.TopicsCovered = request.TopicsCovered;
                updatedLesson.Notes = request.Notes;
                updatedLesson.LessonDate = request.LessonDate;
                updatedLesson.StartTime = new DateTime(updatedLesson.StartTime.Year, updatedLesson.StartTime.Month, updatedLesson.StartTime.Day,
                            request.StartTime.Hour, request.StartTime.Minute, 0);
                updatedLesson.EndTime = new DateTime(updatedLesson.EndTime.Year, updatedLesson.EndTime.Month, updatedLesson.EndTime.Day,
                            request.EndTime.Hour, request.EndTime.Minute, 0);



                //List<Attendance> updatedAttend = new List<Attendance>();

                //foreach (var attend in lessons)
                //{
                //    attend.Status = _dbContext.Attendances
                //    Attendance newAttend = new Attendance()
                //    {
                //        Lesson = updatedLesson,
                //        LessonId = updatedLesson.Id,
                //        Student = attend.Student,
                //        StudentId = attend.StudentId,
                //        Status = attend.Status,
                //        AttendanceDate = updatedLesson.StartTime
                //    };
                //    updatedAttend.Add(newAttend);
                //}


                _dbContext.Attendances.UpdateRange(lessons);
                //await _dbContext.SaveChangesAsync();

                return new SuccessDataResult<UpdateLessonRequestCommand>(request, "Lesson update successfully");
            }

            throw new Exception("error message");

        }
    }
}
