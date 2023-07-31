using SMSDomain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMSDomain.Entities
{
    public class Quiz : BaseAuditableEntity
    {
        public Module Module { get; set; } = null!;
        public int ModuleId { get; set; }
        public string Name { get; set; } = null!;
        public string? TopicsCovered { get; set; } 

        public DateTime QuizDate { get; set; } 
        //public QuizMark? QuizMark { get; set; }
        public Mark Mark { get; set; }
        public int MarkId { get; set;}
    }
}
