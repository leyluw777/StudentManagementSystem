using Application.Common.Mappings;
using SMSDomain.Entities;
using SMSDomain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Students.Queries
{
    public class GetStudentByIdQueryResponse : IMapFrom<Student>
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
        public string? Fin { get; set; } = null!;
      
        public double? AverageGrade { get; set; }


        //  public int AddressId { get; set; }
        public string? Address { get; set; }

       
        public string? Country { get; set; }
        public string? City { get; set; }
        public List<string> PhoneNumbers { get; set; }
        public List<string> Courses { get; set; }



        public List<string> Groups { get; set; } = null!;
       

        public Status Status { get; set; }

        public GraduatedStatus? GraduatedStatus { get; set; }
       
        public LeftStatus? LeftStatus { get; set; }
    
        public StoppedStatus? StoppedStatus { get; set; }
       
      
    }
}
