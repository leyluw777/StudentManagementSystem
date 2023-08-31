using Application.Common.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Lessons.Commands
{
    public class DeleteLessonRequestCommand : IRequest<IDataResult<DeleteLessonRequestCommand>>
    {
        public int Id { get; set; }
    }
}
