using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Lessons.Queries
{
    public class GetLessonsByGroupTeacherRequest : IRequest<GetLessonsByGroupTeacherResponse>
    {
        public GetLessonsByGroupTeacherRequest(string id)
        {
            TeacherId = id;
        }

        public string? TeacherId { get; set; }
    }
}
