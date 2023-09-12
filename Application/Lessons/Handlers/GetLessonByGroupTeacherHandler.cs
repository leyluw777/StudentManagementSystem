using Application.Common.Interfaces;
using Application.Lessons.Queries;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SMSDomain.Entities;
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
            var groupTeacher = _appDbContext.GroupTeacher.FirstOrDefault(x => x.TeacherId == request.TeacherId);
            var groupLessons = new List<SMSDomain.Entities.Lesson>();
            var allLessons = _appDbContext.Lessons.Where(x => x.GroupId == groupTeacher.GroupId).ToList();

             
                if (allLessons != null)
                {

                foreach (var lesson in allLessons)
                {


                    groupLessons.Add(lesson);
                
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
