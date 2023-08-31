using Application.Common.Interfaces;
using Application.Groups.Queries;
using Application.Students.Queries;
using Application.Students;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SMSDomain.Entities;

namespace Application.Groups.Handlers
{
    public class GetAllGroupsHandler : IRequestHandler<GetAllGroupsQueryRequest, GetAllGroupsQueryResponse>
    {
        private readonly IApplicationDbContext _appDbContext;
        private readonly IMapper _mapper;


        public GetAllGroupsHandler(IApplicationDbContext appDbContext, IMapper mapper)
        {
            _appDbContext = appDbContext;
            _mapper = mapper;
        }


        
        public async Task<GetAllGroupsQueryResponse> Handle(GetAllGroupsQueryRequest request, CancellationToken cancellationToken)
        {
            List<Group> groups = new List<Group>();
            var groupsAll = await _appDbContext.Groups.ToListAsync();
            foreach (var gr in groupsAll)
            {
                var groupOne = _mapper.Map<Group>(gr);
                groups.Add(groupOne);
            }

            return new GetAllGroupsQueryResponse()
            {
                Groups = groups,
            };
        }
    }
}
