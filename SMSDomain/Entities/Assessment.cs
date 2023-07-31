using SMSDomain.Common;
using SMSDomain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMSDomain.Entities
{
    public class Assessment  : BaseAuditableEntity
    {
        public AssessmentType AssessmentType { get; set; }
        public Mark Mark { get; set; }   
        public int MarkId { get; set; }
    }
}
