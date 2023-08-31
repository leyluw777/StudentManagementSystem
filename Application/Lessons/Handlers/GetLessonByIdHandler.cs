using Application.Common.Interfaces;
using Application.Lessons.Queries;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Lessons.Handlers
{
    public class GetLessonByIdHandler : IRequestHandler<GetLessonByIdRequestCommand, GetLessonByIdResponseCommand>
    {
        private readonly IApplicationDbContext _appDbContext;
        private readonly IMapper _mapper;

        public GetLessonByIdHandler(IApplicationDbContext appDbContext, IMapper mapper)
        {
            _appDbContext = appDbContext;
            _mapper = mapper;
        }
        public async Task<GetLessonByIdResponseCommand> Handle(GetLessonByIdRequestCommand request, CancellationToken cancellationToken)
        {

            var lessonById = _appDbContext.Lessons.FirstOrDefault(x => x.Id == request.Id);
            return new GetLessonByIdResponseCommand()
            {
                Id = lessonById.Id,
                Module = lessonById.ModuleId,
                Name = lessonById.Name,
                Group = _appDbContext.Groups.FirstOrDefault(x => x.Id == lessonById.GroupId)?.Name,
                TopicsCovered = lessonById.TopicsCovered,
                Notes = lessonById.Notes,
                LessonDate = lessonById.LessonDate,
                StartTime = lessonById.StartTime,
                EndTime = lessonById.EndTime
            };
            throw new NotImplementedException();
        }
    }
}
