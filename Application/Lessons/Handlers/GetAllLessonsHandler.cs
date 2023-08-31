using Application.Lesson.Queries;
using MediatR;
using Application.Common.Interfaces;
using Application.Students.Queries;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SMSDomain.Entities;


namespace Application.Lessons.Handlers
{
	public class GetAllLessonsHandler : IRequestHandler<GetAllLessonsRequestQuery, GetAllLessonsResponseQuery>
	{


		private readonly IApplicationDbContext _appDbContext;
		private readonly IMapper _mapper;


		public GetAllLessonsHandler(IApplicationDbContext appDbContext, IMapper mapper)
		{
			_appDbContext = appDbContext;
			_mapper = mapper;
		}



		public async Task<GetAllLessonsResponseQuery> Handle(GetAllLessonsRequestQuery request, CancellationToken cancellationToken)
		{
			List<SMSDomain.Entities.Lesson> lessons = new List<SMSDomain.Entities.Lesson>();
			var dbLessons = await _appDbContext.Lessons.ToListAsync();
			foreach (var lesson in dbLessons)
			{
				var lessonOne = _mapper.Map<SMSDomain.Entities.Lesson>(lesson);
				lessons.Add(lessonOne);
			}

			return new GetAllLessonsResponseQuery()
			{
				Lessons = lessons
			};
		}
	}
}