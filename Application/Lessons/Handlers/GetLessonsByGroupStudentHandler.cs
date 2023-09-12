using Application.Common.Interfaces;
using Application.Lesson.Queries;
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
	public class GetLessonsByGroupStudentHandler : IRequestHandler<GetLessonsByGroupRequest, GetLessonsByGroupResponse>
	{

		private readonly IApplicationDbContext _appDbContext;
		
		private readonly IMapper _mapper;


		public GetLessonsByGroupStudentHandler(IApplicationDbContext appDbContext, IMapper mapper)
		{
			_appDbContext = appDbContext;
			_mapper = mapper;
		}

		public async Task<GetLessonsByGroupResponse> Handle(GetLessonsByGroupRequest request, CancellationToken cancellationToken)
		{
			var groupstudent = _appDbContext.GroupStudent.FirstOrDefault(x => x.StudentId == request.StudentId);
			var groupLessons = new List<SMSDomain.Entities.Lesson>();

				var allLessons = _appDbContext.Lessons.Where(x => x.GroupId == groupstudent.GroupId).ToList();

				if ( allLessons != null ) {
					foreach(var lesson in allLessons ) { 
				
					
					groupLessons.Add(lesson);
				}
				}
			
		
		
			return new GetLessonsByGroupResponse()
			{
				Lessons = groupLessons
			};
			
			throw new NotImplementedException();
		}
	}
}
