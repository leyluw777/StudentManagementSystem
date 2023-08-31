using Application.Common.Interfaces;
using Application.Common.Results;
using Application.Lessons.Commands;
using Application.Students.Commands;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Lessons.Handlers
{
    public class DeleteLessonHandler : IRequestHandler<DeleteLessonRequestCommand, IDataResult<DeleteLessonRequestCommand>>
    {
        private readonly IApplicationDbContext _appDbContext;
        private readonly IMapper _mapper;

        public DeleteLessonHandler(IApplicationDbContext appDbContext, IMapper mapper)
        {
            _appDbContext = appDbContext;
            _mapper = mapper;
        }

        public async Task<IDataResult<DeleteLessonRequestCommand>> Handle(DeleteLessonRequestCommand request, CancellationToken cancellationToken)
        {
            var deletedLesson = _appDbContext.Lessons.FirstOrDefault(x => x.Id == request.Id);
            if (deletedLesson == null)
            {
                throw new Exception("Lesson not found");
            }
            else
            {
                _appDbContext.Lessons.Remove(deletedLesson);
            }
            await _appDbContext.SaveChangesAsync(cancellationToken);
            return new SuccessDataResult<DeleteLessonRequestCommand>(request, "Lesson deleted successfully");
        }
    }
}

