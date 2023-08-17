using Application.Common.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Students.Commands
{
    public class DeleteStudentRequestCommand : IRequest<IDataResult<DeleteStudentRequestCommand>>
    {
        public string Id { get;set; }
    }
}
