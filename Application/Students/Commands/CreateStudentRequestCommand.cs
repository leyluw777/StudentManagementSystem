using Application.Common.Results;
using MediatR;
using SMSDomain.Entities;
using SMSDomain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Students.Commands
{
    public class CreateStudentRequestCommand : IRequest<CreateStudentResponseCommand>
    {
        private string _number;
        private string _prefix;
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; } 
        public string FathersName { get; set; } 
        public int Age { get; set; }
        public DateTime BirthDate { get; set; }
        public byte Gender { get; set; }
       // public string? Image { get; set; }
        public string Fin { get; set; } 


       


        ////  public int AddressId { get; set; }
        public string District { get; set; }
        public string StreetAddress { get; set; }
        public int HouseNo { get; set; }
        public int ZipCode { get; set; }

        public int HomeNumber { get; set; }

        public string? Country { get; set; }
        public string? City { get; set; }
        public List<string> Phonenumber { get; set; }
     

        //public string Number { get; set; }


        public string Course { get; set; }


        public string Group { get; set; }   
        //public List<Group> Groups { get; set; } = null!;

        public int Status { get; set; }

        //public GraduatedStatus? GraduatedStatus { get; set; }

        //public LeftStatus? LeftStatus { get; set; }

        //public StoppedStatus? StoppedStatus { get; set; }
    }
}
