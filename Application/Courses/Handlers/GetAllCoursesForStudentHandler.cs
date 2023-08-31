using Application.Common.Interfaces;
using Application.Courses.Queries;
using Application.Groups.Queries;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Courses.Handlers
{
    public class GetAllCoursesForStudentHandler : IRequestHandler<GetAllCoursesForStudentRequest, GetAllCoursesForStudentResponse>
    {
        private readonly IApplicationDbContext _appDbContext;
        private readonly IMapper _mapper;

        public GetAllCoursesForStudentHandler(IApplicationDbContext appDbContext, IMapper mapper)
        {
            _appDbContext = appDbContext;
            _mapper = mapper;
        }

        public async Task<GetAllCoursesForStudentResponse> Handle(GetAllCoursesForStudentRequest request, CancellationToken cancellationToken)
        {
            List<SMSDomain.Entities.Course> courses = new List<SMSDomain.Entities.Course>();
            var coursessAll = await _appDbContext.Courses.ToListAsync();
            foreach (var cr in coursessAll)
            {
                var courseOne = _mapper.Map<SMSDomain.Entities.Course>(cr);
                courses.Add(courseOne);
            }

            return new GetAllCoursesForStudentResponse()
            {
                Courses = courses,
            };


     
        }
    }
}
