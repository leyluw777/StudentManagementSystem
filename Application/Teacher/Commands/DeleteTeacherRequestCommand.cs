using Application.Common.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Teacher.Commands
{
    public class DeleteTeacherRequestCommand : IRequest< IDataResult<DeleteTeacherRequestCommand>>
    {
        public string Id { get; set; }
    }
}
