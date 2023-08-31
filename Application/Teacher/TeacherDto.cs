using Application.Common.Mappings;
using SMSDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Teacher
{
    public class TeacherDto : IMapFrom<SMSDomain.Entities.Teacher>
    {
        public string Id { get; set; }
        public string Name { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string FathersName { get; set; } = null!;
        public int? Age { get; set; }
        public DateTime? BirthDate { get; set; }
        public byte? Gender { get; set; }
        public string? Image { get; set; }
        public string Fin { get; set; } = null!;
        public DateTime? JoinedDate { get; set; }

        public FirstLogin? FirstLogin { get; set; }



        //  public int AddressId { get; set; }




        public string Description { get; set; }
        public string Experience { get; set; }

        public bool ActiveStatus { get; set; }

        //   public int AddressId { get; set; }

        public Address Address { get; set; }
        public List<PhoneNumber> PhoneNumbers { get; set; }

        public List<CourseTeacher> courseTeachers { get; set; }

    }
}
