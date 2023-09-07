using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Lessons.Queries
{
    public class GetLessonsByGroupTeacherResponse
    {
        public List<SMSDomain.Entities.Lesson>? Lessons { get; set; }

    }
}
