using Application.Common.Interfaces;
using Application.Lessons.Commands;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using SMSDomain.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Lessons.Handlers
{
	public class CreateLessonHandler : IRequestHandler<CreateLessonRequestCommand, CreateLessonResponseCommand>
	{
		private readonly IApplicationDbContext _appDbContext;
		private readonly IMapper _mapper;
		private readonly UserManager<SMSDomain.Identity.AppUser> _userManager;
		private readonly RoleManager<AppRole> _roleManager;

		public CreateLessonHandler(IApplicationDbContext appDbContext, IMapper mapper, UserManager<SMSDomain.Identity.AppUser> userManager, RoleManager<AppRole> roleManager)
		{
			_appDbContext = appDbContext;
			_mapper = mapper;
			_userManager = userManager;
			_roleManager = roleManager;
		}


		public async Task<CreateLessonResponseCommand> Handle(CreateLessonRequestCommand request, CancellationToken cancellationToken)
		{
		SMSDomain.Entities.Lesson newLesson = new SMSDomain.Entities.Lesson(){
				GroupId = request.Group != null
				  ? _appDbContext.Groups.FirstOrDefault(x => x.Name == request.Group)?.Id
				  : null,

				ModuleId = request.Module != null
				  ? _appDbContext.Modules.FirstOrDefault(x => x.Id == request.Module)?.Id
				  : null,
                Name = request.Name,
				TopicsCovered = request.TopicsCovered,
				Notes = request.Notes,
				LessonDate = request.LessonDate,
				StartTime = request.StartTime,
				EndTime = request.EndTime,	
			};
			await _appDbContext.Lessons.AddAsync(newLesson);
			await _appDbContext.SaveChangesAsync(cancellationToken);
			return new CreateLessonResponseCommand()
			{
				Id = newLesson.Id,
				Group = newLesson.GroupId != null
				  ? _appDbContext.Groups.FirstOrDefault(x => x.Id == newLesson.GroupId)?.Name
				  : null,

				Module = newLesson.ModuleId != null
				  ? _appDbContext.Modules.FirstOrDefault(x => x.Id == newLesson.ModuleId)?.Id
				  : null,

                Name = newLesson.Name,
                TopicsCovered = newLesson.TopicsCovered,
                Notes = newLesson.Notes,
                LessonDate = newLesson.LessonDate,
                StartTime = newLesson.StartTime,
                EndTime = newLesson.EndTime,
            };
		}
	}
}
