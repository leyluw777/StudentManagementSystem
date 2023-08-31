using Application.Common.Interfaces;
using Application.Common.Results;
using Application.Lessons.Commands;
using Application.Students.Commands;
using AutoMapper;
using MediatR;
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
            var updatedLesson = _dbContext.Lessons.FirstOrDefault(x => x.Id == request.Id);
            if (updatedLesson != null)
            {

                updatedLesson.Id = request.Id;
                updatedLesson.Name = request.Name;
                updatedLesson.ModuleId = request.Module;
                updatedLesson.GroupId = _dbContext.Groups.FirstOrDefault(x => x.Name == request.Group).Id;
    

                updatedLesson.StartTime = new DateTime(updatedLesson.StartTime.Year, updatedLesson.StartTime.Month, updatedLesson.StartTime.Day,
                            request.StartTime.Hour, request.StartTime.Minute, 0);
                updatedLesson.EndTime = new DateTime(updatedLesson.EndTime.Year, updatedLesson.EndTime.Month, updatedLesson.EndTime.Day,
                            request.EndTime.Hour, request.EndTime.Minute, 0);
                await _dbContext.SaveChangesAsync();

                return new SuccessDataResult<UpdateLessonRequestCommand>(request, "Lesson update successfully");
            }

            throw new Exception("error message");

        }
    }
}
