using Application.Common.Interfaces;
using Application.Students.Queries;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SMSDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Students.Handlers
{
    public class GetStudentByIdHandler : IRequestHandler<GetStudentByIdQueryRequest, GetStudentByIdQueryResponse>
    {
        private readonly IApplicationDbContext _appDbContext;
        private readonly IMapper _mapper;

        public GetStudentByIdHandler(IApplicationDbContext appDbContext, IMapper mapper)
        {
            _appDbContext = appDbContext;
            _mapper = mapper;
        }

        public async Task<GetStudentByIdQueryResponse> Handle(GetStudentByIdQueryRequest request, CancellationToken cancellationToken)
        {
            
            var StudentById = await  _appDbContext.Students.FirstOrDefaultAsync(student => student.Id == request.Id);
            var student = _mapper.Map<GetStudentByIdQueryResponse>(StudentById);
            return student;

        }
    }
}
