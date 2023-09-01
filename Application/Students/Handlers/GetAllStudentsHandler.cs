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
    public class GetAllStudentsHandler : IRequestHandler<GetAllStudentsQueryRequest, GetAllStudentsQueryResponse>
    {

        private readonly IApplicationDbContext _appDbContext;
        private readonly IMapper _mapper;


        public GetAllStudentsHandler(IApplicationDbContext appDbContext, IMapper mapper)
        {
            _appDbContext = appDbContext;
            _mapper = mapper;   
        }


        public async Task<GetAllStudentsQueryResponse> Handle(GetAllStudentsQueryRequest request, CancellationToken cancellationToken)
        {

            List<StudentDto> students = new List<StudentDto>();
            var students1 = await _appDbContext.Students.Include(x=>x.GroupStudents).ThenInclude(x=>x.Group).ToListAsync();
            foreach(var student in students1)
            {
                var a = student.GroupStudents.FirstOrDefault(x => x.StudentId == student.Id).Group.Name;
                var studentOne = new StudentDto() {
                    Id = student.Id,
                    Name = student.Name,
                    Surname = student.Surname,
                    FathersName = student.FathersName,
                    Email = student.Email,
                    Fin = student.Fin,
                    AverageGrade = student.AverageGrade,
                    Status = (SMSDomain.Enums.Status)student.Status,
                    Group = student.GroupStudents.FirstOrDefault(x => x.StudentId == student.Id).Group.Name,
                    };
                students.Add(studentOne);
            }

            return new GetAllStudentsQueryResponse()
            {
                Students = students,
            };
        }
    }
}
