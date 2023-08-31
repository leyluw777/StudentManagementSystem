using Application.AppUser.Commands;
using Application.Common.Interfaces;
using Application.Common.JWT;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using SMSDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.AppUser.Handler
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserRequestCommand, LoginUserResponseCommand>
    {
        private readonly ITokenHandler _tokenHandler;
        private readonly UserManager<SMSDomain.Identity.AppUser> _userManager;
        private readonly IApplicationDbContext _dbContext;

        public LoginUserCommandHandler(ITokenHandler tokenHandler, UserManager<SMSDomain.Identity.AppUser> userManager, IApplicationDbContext dbContext)
        {
            _tokenHandler = tokenHandler;
            _userManager = userManager;
            _dbContext  = dbContext;
        }
        public async Task<LoginUserResponseCommand> Handle(LoginUserRequestCommand request, CancellationToken cancellationToken)
        {

           
            var user = await _userManager.FindByNameAsync(request.Username);
            var firstLogin = _dbContext.FirstLogins.FirstOrDefault(x => x.UserId == user.Id);

			if (user == null) throw new Exception("User not found");
            var result = await _userManager.CheckPasswordAsync(user, request.Password);
                
            if (!result) throw new Exception("Authentication error");
            var accessToken = await  _tokenHandler.CreateAccessToken(1200, user);

            if (firstLogin != null) //varsa
            {
				_dbContext.FirstLogins.Remove(firstLogin);
				await _dbContext.SaveChangesAsync();
				return new LoginUserResponseCommand()
                {
                    Token = accessToken,
                    IsFirstLogin = true
                };

            }
            return new LoginUserResponseCommand()
            {
                Token = accessToken,
                IsFirstLogin = false
            };

        }
    }
}
