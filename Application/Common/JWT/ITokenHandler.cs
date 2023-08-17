using Application.AppUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.JWT
{
    public interface ITokenHandler
    {
        Task<TokenDto> CreateAccessToken(int second, SMSDomain.Identity.AppUser appUser);
    }
}
