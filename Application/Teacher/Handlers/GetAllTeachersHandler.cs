using Application.Common.Interfaces;
using Application.Teacher.Queries;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Teacher.Handlers
{
    public class GetAllTeachersHandler : IRequestHandler<GetAllTeachersQueryRequest, GetAllTeachersQueryResponse>
    {

        private readonly IApplicationDbContext _appDbContext;
        private readonly IMapper _mapper;


        public GetAllTeachersHandler(IApplicationDbContext appDbContext, IMapper mapper)
        {
            _appDbContext = appDbContext;
            _mapper = mapper;   
        }


        public async Task<GetAllTeachersQueryResponse> Handle(GetAllTeachersQueryRequest request, CancellationToken cancellationToken)
        {
            List<TeacherDto> teachers = new List<TeacherDto>();
            var teachers1 = await _appDbContext.Teachers.ToListAsync();
            foreach(var teacher in teachers1)
            {
                var teacherOne = _mapper.Map<TeacherDto>(teacher);
                teachers.Add(teacherOne);
            }

            return new GetAllTeachersQueryResponse()
            {
                Teachers = teachers,
            };
        }
    }
}
