using Application.Common.Results;
using SMSDomain.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Students.Commands
{
    public class CreateStudentResponseCommand 
    {
        public string Id { get; set; }
        public string Username { get; set; } 
        public string Password { get; set; }
        //public SuccessDataResult<CreateStudentRequestCommand> DataResult { get; set; }
    }
}
