using SMSDomain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMSDomain.Entities
{
    public class Homework : BaseAuditableEntity
    {
        public Lesson Lesson { get; set; } = null!;
        public int LessonId { get; set; }
        public DateTime HomeworkDate { get; set; }
        public string LessonName { get; set; }
        public bool FilesAttached { get; set; } 
        public string FilePath { get; set; }
        public Mark Mark { get; set; }
        public int MarkId { get; set; }
        public DateTime Deadline { get;set; }

    }
}
