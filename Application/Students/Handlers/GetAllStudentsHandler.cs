using Application.Common.Interfaces;
using Application.Students.Queries;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Students.Handlers
{
    public class GetAllStudentsHandler : IRequestHandler<GetAllStudentsQueryRequest, GetAllStudentsResponse>
    {

        private readonly IApplicationDbContext _appDbContext;
        private readonly IMapper _mapper;


        public GetAllStudentsHandler(IApplicationDbContext appDbContext, IMapper mapper)
        {
            _appDbContext = appDbContext;
            _mapper = mapper;   
        }


        public async Task<GetAllStudentsResponse> Handle(GetAllStudentsQueryRequest request, CancellationToken cancellationToken)
        {
            List<StudentDto> students = new List<StudentDto>();
            var students1 = await _appDbContext.Students.ToListAsync();
            foreach(var student in students1)
            {
                var studentOne = _mapper.Map<StudentDto>(student);
                students.Add(studentOne);
            }

            return new GetAllStudentsResponse()
            {
                Students = students,
            };
        }
    }
}
