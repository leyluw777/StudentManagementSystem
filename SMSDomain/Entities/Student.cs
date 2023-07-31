using SMSDomain.Common;
using SMSDomain.Enums;
using SMSDomain.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMSDomain.Entities
{
    public class Student : AppUser
    {
        

        public DateTime LastLoginDate { get; set; }
        public double AverageGrade { get; set; }


       
        public int AddressId { get; set; }
        public Address Address { get; set; }
        public ICollection<PhoneNumber> PhoneNumbers { get; set; } 
        public ICollection<Course> Courses { get; set; }


        public ICollection<Attendance> Attendances { get; set; }
       
        public ICollection<Group> Groups { get; set; } = null!;
        public ICollection<Mark> Marks { get; set; }

        public Status Status { get; set; }
      
        public GraduatedStatus? GraduatedStatus { get; set; }
        public LeftStatus? LeftStatus { get; set; }
        public StoppedStatus? StoppedStatus { get; set; }

        [NotMapped]
        public bool FirstTimeLogin { get; set; } = false;


    }
}
