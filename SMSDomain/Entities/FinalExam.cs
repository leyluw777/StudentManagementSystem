using SMSDomain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMSDomain.Entities
{
    public class FinalExam : BaseAuditableEntity
    {
        public Course Course { get; set; } = null!;
        public int CourseId { get; set; }
        public string Name { get; set; } = null!;
        public string? UsedTechnologies { get; set; }
        public DateTime ExamDate { get; set; }
        //public FinalExamMark? Mark { get; set; }
        public Mark Mark { get; set; } 
        public int MarkId { get; set; }

    }
}
