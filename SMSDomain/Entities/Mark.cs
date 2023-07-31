using SMSDomain.Common;
using SMSDomain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMSDomain.Entities
{
    public class Mark : BaseAuditableEntity
    {
        public int Points { get; set; }
        public float MaxPoints { get; set; }
        public string OverallGrade { get; set; }
        public FinalExam  FinalExam { get; set; } = null!;
        public int FinalExamId { get; set; }
        public ICollection<Quiz> Quizzes { get; set; } = null!;
        public ICollection<Homework> Homeworks { get; set; } = null!;

        public Student Student { get; set; } 
        public int StudentId { get; set; }
        public ICollection<Assessment> Assessments { get; set; } 

        
      
    }
}
