using SMSDomain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMSDomain.Entities
{
    public class Module : BaseAuditableEntity
    {
        public int CourseId { get; set; }
        public Course Course { get; set; } = null!;
        public string Name { get; set; } = null!;
        public int? TotalHours { get; set; }
        public List<Quiz>? Quizzes { get; set; }
        public List<Lesson>? Lessons { get; set; }

    }
}
