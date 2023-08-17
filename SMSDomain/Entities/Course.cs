using SMSDomain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMSDomain.Entities
{
    public class Course : BaseAuditableEntity
    {
        public string Name { get; set; }
        public DateTime JoinedDate { get; set; }
        public int TotalModules { get; set; }
        public int TotalHours { get; set; }
        public int? FinalExamId { get;set; }
        public FinalExam? FinalExam { get; set; } 
        public List<CourseStudent>? CourseStudents { get;  } = null!;
        public List<Module>? Modules { get; set; }
        public List<Teacher>? Teachers { get; set; }

        public List<Coordinator>? Coordinators { get; set; }

    }
}
