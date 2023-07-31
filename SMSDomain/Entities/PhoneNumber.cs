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
        public Guid StudentId { get; set; } 
        public Teacher Teacher { get; set; }
        public Guid TeacherId { get;set; }
        public Coordinator Coordinator { get; set; }
        public Guid CoordinatorId { get; set; }  
         
        public ICollection<NumberPrefix> NumberPrefixes { get; set; }
    }
}
