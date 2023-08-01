using SMSDomain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMSDomain.Entities
{
    public class Lesson : BaseAuditableEntity
    {
        public int ModuleId { get; set; }
        public Module Module { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string? TopicsCovered { get; set; }
        public string? Notes { get; set; }
        public DateTime LessonDate { get; set; }
        public DateTime StartTime { get; set; } 
        public DateTime EndTime { get; set; }

        public List<Homework> Homeworks { get; set; }
        public List<Attendance> Attendances { get; set; }
    }
}
