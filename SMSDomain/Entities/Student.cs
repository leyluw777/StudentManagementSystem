﻿using SMSDomain.Common;
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
        

        public DateTime? LastLoginDate { get; set; }
        public double? AverageGrade { get; set; }


       
      //  public int AddressId { get; set; }
        public Address? Address { get; set; }

        public Country? Country { get; set; }
        public int? CountryId { get; set; }
        public City? City { get; set; }
        public int? CityId { get; set; } 
        public List<PhoneNumber>? PhoneNumbers { get; set; }
        public List<CourseStudent>? CourseStudents { get; }


        public List<Attendance>? Attendances { get; set; }
       
        public List<GroupStudent>? GroupStudents { get; set; } 
        public List<Mark>? Marks { get; set; }

        public Status? Status { get; set; }
      
        public GraduatedStatus? GraduatedStatus { get; set; }
        public int? GraduatedStatusId { get; set; }
        public LeftStatus? LeftStatus { get; set; }
        public int? LeftStatusId { get; set; }
        public StoppedStatus? StoppedStatus { get; set; }
        public int? StoppedStatusId { get; set; }
    
    }
}
