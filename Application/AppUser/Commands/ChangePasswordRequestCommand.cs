using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.AppUser.Commands
{
    public class ChangePasswordRequestCommand : IRequest<ChangePasswordResponseCommand>
    {

        public string Password { get; set; }
        public string NewPassword { get; set; }
        public string ConfirmPassword { get; set;}
    }
}
