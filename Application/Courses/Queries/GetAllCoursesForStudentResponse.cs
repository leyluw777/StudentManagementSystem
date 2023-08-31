using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Courses.Queries
{
    public class GetAllCoursesForStudentResponse
    {
        public List<SMSDomain.Entities.Course>? Courses { get; set; }
    }
}
