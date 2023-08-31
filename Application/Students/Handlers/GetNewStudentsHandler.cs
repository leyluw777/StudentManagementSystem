using Application.AppUser.Commands;
using Application.Common.Interfaces;
using Application.Common.JWT;
using Application.Students.Commands;
using Application.Students.Queries;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SMSDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Students.Handlers
{
	public class GetNewStudentsHandler : IRequestHandler<GetNewStudentsRequest, GetNewStudentsResponse>
	{
		private readonly ITokenHandler _tokenHandler;
		private readonly UserManager<SMSDomain.Identity.AppUser> _userManager;
		private readonly IApplicationDbContext _dbContext;

		public GetNewStudentsHandler(ITokenHandler tokenHandler, UserManager<SMSDomain.Identity.AppUser> userManager, IApplicationDbContext dbContext)
		{
			_tokenHandler = tokenHandler;
			_userManager = userManager;
			_dbContext = dbContext;
		}
		public async Task<GetNewStudentsResponse> Handle(GetNewStudentsRequest request, CancellationToken cancellationToken)
		{
			List<FirstLogin> newStudentsList = new List<FirstLogin>();
			var newStudents = await _dbContext.FirstLogins.ToListAsync();
			foreach (var student in newStudents)
			{
				var studentOne = new FirstLogin()
				{
					UserId = student.UserId,
					Name = student.Name,
					Surname = student.Surname, 
					FathersName = student.FathersName,
					UserName = student.UserName,
					Password = student.Password
				};
				newStudentsList.Add(studentOne);
			}
			return new GetNewStudentsResponse()
			{
				NewStudents = newStudentsList
			};

		}
	}
}
