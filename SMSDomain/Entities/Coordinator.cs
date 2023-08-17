using SMSDomain.Common;
using SMSDomain.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMSDomain.Entities
{
    public class Coordinator : AppUser
    {
        public List<Course>? Courses { get; set; }
        public bool ActiveStatus { get; set; }

      
        public Address? Address { get; set; }
        public List<PhoneNumber>? PhoneNumbers { get; set; }
     

    }
}
