//using Application.Admin.Queries;
//using Application.Common.Interfaces;
//using Application.Common.JWT;
//using MediatR;
//using Microsoft.AspNetCore.Identity;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Application.Admin.Handler
//{
//	public class LoginAdminQueryHandler : IRequestHandler<LoginAdminRequestQuery, LoginAdminResponseQuery>
//	{

//		private readonly UserManager<SMSDomain.Identity.AppUser> _userManager;
//		private readonly IApplicationDbContext _dbContext;

//		public LoginAdminQueryHandler(UserManager<SMSDomain.Identity.AppUser> userManager, IApplicationDbContext dbContext)
//		{
//			_userManager = userManager;
//			_dbContext = dbContext;
//		}

//		public async Task<LoginAdminResponseQuery> Handle(LoginAdminRequestQuery request, CancellationToken cancellationToken)
//		{
//			var user = await _userManager.FindByNameAsync(request.Username);
//			if (user.)
//			return 
//		}
//	}
//}
