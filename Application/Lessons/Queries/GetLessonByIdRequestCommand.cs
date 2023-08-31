using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Lessons.Queries
{
    public class GetLessonByIdRequestCommand: IRequest<GetLessonByIdResponseCommand>
    {
        public GetLessonByIdRequestCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
