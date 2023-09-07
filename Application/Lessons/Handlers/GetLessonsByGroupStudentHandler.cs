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
		private readonly UserManager<SMSDomain.Identity.AppUser> _userManager;
		private readonly IMapper _mapper;


		public GetLessonsByGroupStudentHandler(IApplicationDbContext appDbContext, IMapper mapper)
		{
			_appDbContext = appDbContext;
			_mapper = mapper;
		}

		public async Task<GetLessonsByGroupResponse> Handle(GetLessonsByGroupRequest request, CancellationToken cancellationToken)
		{
			var groupstudents = _appDbContext.GroupStudent.Where(x => x.StudentId == request.StudentId).ToList();
			var groupLessons = new List<SMSDomain.Entities.Lesson>();

			foreach( var student in groupstudents )
			{

				var oneLesson = await _appDbContext.Lessons.FirstOrDefaultAsync(x => x.GroupId == student.GroupId);
				if ( oneLesson != null ) {
					var mappedLesson = _mapper.Map<SMSDomain.Entities.Lesson>(oneLesson);
					groupLessons.Add(mappedLesson);
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
