using Application.Common.Interfaces;
using Application.Lessons.Queries;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Lessons.Handlers
{
    public class GetLessonByGroupTeacherHandler : IRequestHandler<GetLessonsByGroupTeacherRequest, GetLessonsByGroupTeacherResponse>
    {

        private readonly IApplicationDbContext _appDbContext;
        private readonly UserManager<SMSDomain.Identity.AppUser> _userManager;
        private readonly IMapper _mapper;


        public GetLessonByGroupTeacherHandler(IApplicationDbContext appDbContext, IMapper mapper)
        {
            _appDbContext = appDbContext;
            _mapper = mapper;
        }

        public async Task<GetLessonsByGroupTeacherResponse> Handle(GetLessonsByGroupTeacherRequest request, CancellationToken cancellationToken)
        {
            var groupTeachers = _appDbContext.GroupTeacher.Where(x => x.TeacherId == request.TeacherId).ToList();
            var groupLessons = new List<SMSDomain.Entities.Lesson>();

            foreach (var student in groupTeachers)
            {

                var oneLesson = await _appDbContext.Lessons.FirstOrDefaultAsync(x => x.GroupId == student.GroupId);
                if (oneLesson != null)
                {
                    var mappedLesson = _mapper.Map<SMSDomain.Entities.Lesson>(oneLesson);
                    groupLessons.Add(mappedLesson);
                }

            }


            return new GetLessonsByGroupTeacherResponse()
            {
                Lessons = groupLessons
            };

            throw new NotImplementedException();
        }
    }
}
