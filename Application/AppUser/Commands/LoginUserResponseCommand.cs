using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.AppUser.Commands
{
    public class LoginUserResponseCommand
    {
        public TokenDto Token { get; set; }
        public bool IsFirstLogin { get; set; }

    }
}
