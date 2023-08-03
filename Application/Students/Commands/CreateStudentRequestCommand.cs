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
        public string Name { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string FathersName { get; set; } = null!;
        public int Age { get; set; }
        public DateTime BirthDate { get; set; }
        public byte Gender { get; set; }
        public string? Image { get; set; }
        public string Fin { get; set; } = null!;


       


        ////  public int AddressId { get; set; }
        public string District { get; set; }
        public string StreetAddress { get; set; }
        public int HouseNo { get; set; }
        public int ZipCode { get; set; }

        public int HomeNumber { get; set; }

        public string Countryname { get; set; }
        public string Cityname { get; set; }
        public string Phonenumber { get; set; }
        public string NumberPrefix { get; set; }

        public string Number { get; set; }


        public List<Course> Courses { get; set; }



        //public List<Group> Groups { get; set; } = null!;

        public int Status { get; set; }

        //public GraduatedStatus? GraduatedStatus { get; set; }

        //public LeftStatus? LeftStatus { get; set; }

        //public StoppedStatus? StoppedStatus { get; set; }
    }
}
