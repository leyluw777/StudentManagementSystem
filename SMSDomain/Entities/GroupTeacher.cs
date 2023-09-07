using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMSDomain.Entities
{
    [Keyless]
    public class GroupTeacher
    {
        public string? TeacherId { get; set; }
        public Teacher? Teacher { get; set;}
        public int? GroupId { get; set; }
        public Group? Group { get; set; }
    }
}
