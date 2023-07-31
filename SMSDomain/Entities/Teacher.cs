using SMSDomain.Common;
using SMSDomain.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SMSDomain.Entities
{
    public class Teacher : AppUser
    {
      
        public string Description { get; set; }
        public string Experience { get; set; }
        
        public bool ActiveStatus { get; set; }

        public int AddressId { get; set; }
        public Address Address { get; set; }
        public ICollection<PhoneNumber> PhoneNumbers { get; set; }

        public ICollection<Course> Courses { get; set; }


    }
}
