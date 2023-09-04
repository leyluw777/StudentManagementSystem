using Application.Common.Mappings;
using SMSDomain.Entities;
using SMSDomain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Students
{
    public class StudentDto  : IMapFrom<Student>
    {
        public string Id { get; set; }
        public string Name { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string FathersName { get; set; } = null!;
        public int Age { get; set; }
        public DateTime BirthDate { get; set; }
        public byte Gender { get; set; }
        public string? Image { get; set; }
        public string Fin { get; set; } = null!;

        public double? AverageGrade { get; set; }


        //  public int AddressId { get; set; }
        public Address Address { get; set; }

        public Country Country { get; set; }
        public City City { get; set; }
        public List<PhoneNumber> PhoneNumbers { get; set; }
        public List<Course> Courses { get; set; }

     //   public List<Attendance>? Attendances { get; set; }

        public string Group { get; set; } = null!;

        public List<Attendance> Attendances { get; set; }


        public Status Status { get; set; }

        public GraduatedStatus? GraduatedStatus { get; set; }

        public LeftStatus? LeftStatus { get; set; }

        public StoppedStatus? StoppedStatus { get; set; }

    }
}
