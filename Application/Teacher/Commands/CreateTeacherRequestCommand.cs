﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Teacher.Commands
{
    public class CreateTeacherRequestCommand: IRequest<CreateTeacherResponseCommand>
    {
        public string Name { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string FathersName { get; set; } = null!;
        public int? Age { get; set; }
        public byte? Gender { get; set; }
        public string? Fin { get; set; } = null!;


        //  public int AddressId { get; set; }
        public string? Address { get; set; }

        public DateTime? BirthDate { get; set; }


        public string? District { get; set; }
        public string? StreetAddress { get; set; }
        public int HouseNo { get; set; }
        public int ZipCode { get; set; }

        public int HomeNumber { get; set; }

        public string? Description { get; set; }
        public string? Experience { get; set; }

        public bool? ActiveStatus { get; set; }
        public List<string>? PhoneNumbers { get; set; }

        public string? Course { get; set; }


		public string? Group { get; set; }
	}
}
