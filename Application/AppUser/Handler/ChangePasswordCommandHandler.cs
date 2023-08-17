using Application.AppUser.Commands;
using Application.Common.Interfaces;
using Application.Common.JWT;
using Azure.Core;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SMSDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.AppUser.Handler
{
    public class ChangePasswordCommandHandler : IRequestHandler<ChangePasswordRequestCommand, ChangePasswordResponseCommand>
    {

      
        private readonly UserManager<SMSDomain.Identity.AppUser> _userManager;
        private readonly IApplicationDbContext _dbContext;
		private readonly ICurrentUser _currentUser;
		public ChangePasswordCommandHandler(UserManager<SMSDomain.Identity.AppUser> userManager, IApplicationDbContext dbContext, ICurrentUser currentUser)
		{

			_userManager = userManager;
			_dbContext = dbContext;
			_currentUser = currentUser;
		}

		public async Task<ChangePasswordResponseCommand> Handle(ChangePasswordRequestCommand request, CancellationToken cancellationToken)
		{
            //var firstLogin = await _dbContext.FirstLogins.FirstOrDefaultAsync(x => x.UserId == request.Id);
            //if (firstLogin != null)
            //{
				var user = await _userManager.FindByNameAsync(_currentUser.UserName);


				if (user == null) throw new Exception("Please check the password");
				var passwordHasher = new PasswordHasher<SMSDomain.Identity.AppUser>(); // Replace AppUser with your user class

				//var hashedRequestedPassword = passwordHasher.HashPassword(user, request.Password);
				var passwordVerificationResult = passwordHasher.VerifyHashedPassword(user, user.PasswordHash, request.Password);
				if (passwordVerificationResult != PasswordVerificationResult.Success) throw new Exception("Old password is not right");
				if (request.NewPassword == request.ConfirmPassword)
				{
					await _userManager.ChangePasswordAsync(user, request.Password, request.NewPassword);
				}
				else
				{
					throw new Exception("New password doesnt match its confirmation");
				}
			
				
				return new ChangePasswordResponseCommand()
				{
					IsChanged = true,
				};
			//}
			
			//else
			//{
			//	return new ChangePasswordResponseCommand()
			//	{
			//		IsChanged = false,
			//	};
			//}
		}
	}
}
