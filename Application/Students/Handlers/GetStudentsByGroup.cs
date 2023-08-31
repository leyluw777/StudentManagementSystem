using Application.Common.Interfaces;
using Application.Students.Queries;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Students.Handlers
{
	//public class GetStudentsByGroup : IRequestHandler<GetStudentByIdQueryRequest, GetStudentByIdQueryResponse>
	//{
	//	private readonly IApplicationDbContext _appDbContext;
	//	private readonly IMapper _mapper;

	//	public GetStudentsByGroup(IApplicationDbContext appDbContext, IMapper mapper)
	//	{
	//		_appDbContext = appDbContext;
	//		_mapper = mapper;
	//	}

	//	public Task<GetStudentByIdQueryResponse> Handle(GetStudentByIdQueryRequest request, CancellationToken cancellationToken)
	//	{
	//		var groupStudent = _appDbContext.Students.()
	//	}
	//}

}
