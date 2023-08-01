using SMSDomain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMSDomain.Entities
{
    public class PhoneNumber : BaseAuditableEntity
    {
        public string Number { get;set ; }

        public Student Student { get; set; } = null!;
        public string StudentId { get; set; } 
        public Teacher Teacher { get; set; }
        public string TeacherId { get;set; }
        public Coordinator Coordinator { get; set; }
        public string CoordinatorId { get; set; }  
         
        public List<NumberPrefix> NumberPrefixes { get; set; }
    }
}
