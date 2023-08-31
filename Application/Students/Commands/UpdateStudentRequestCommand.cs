using Application.Common.Results;
using System.Threading.Tasks;

namespace Application.Students.Commands;
using MediatR;
using SMSDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

    public class UpdateStudentRequestCommand: IRequest<IDataResult<UpdateStudentRequestCommand>>
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Email { get; set; }
        public string? FathersName { get; set; }
        public int Age { get; set; }
        public DateTime BirthDate { get; set; }
        public byte? Gender { get; set; }
        // public string? Image { get; set; }
        public string? Fin { get; set; }


        public double? AverageGrade { get; set; }


        public string? District { get; set; }
        public string? StreetAddress { get; set; }
        public int HouseNo { get; set; }
        public int ZipCode { get; set; }

        public int HomeNumber { get; set; }


       
        public string? Country { get; set; }
        public string? City { get; set; }

        public List<string>? Phonenumbers { get; set; }


        public List<string>? Courses { get; set; }


        public List<string>? Groups { get; set; }
 

        public int Status { get; set; }

    
        public string? leftMessage { get; set; }
        public DateTime LeftDate { get; set; }

        public DateTime GraduatedDate { get; set; }

    public DateTime StoppedDate { get; set; }
    public string? StoppedMessage { get; set; }
    public DateTime ApproximateStartDate { get; set; }



    }
