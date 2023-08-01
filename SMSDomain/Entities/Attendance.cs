using SMSDomain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMSDomain.Entities
{
    public class Attendance : BaseAuditableEntity
    {
        public Lesson Lesson { get; set; } = null!;
        public int LessonId { get; set; }
        public Student Student { get; set; }
        public string StudentId { get; set; }
        public string? SharedNotes { get; set; }
        public string? InternalNotes { get; set; }
        public bool Status { get; set; }
        public DateTime AttendanceDate { get; set; }

    }
}
