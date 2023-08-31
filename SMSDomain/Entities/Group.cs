using SMSDomain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMSDomain.Entities
{
    public class Group : BaseAuditableEntity
    {
        public string Name { get; set; }
        public string? Description { get; set; }

        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public List<GroupStudent>? GroupStudents { get; set; } 
        public List<Lesson>? Lessons { get; set; }

    }
}
