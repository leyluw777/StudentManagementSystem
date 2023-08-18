
namespace WebUI.Areas.Admin.Models
{
	public class CrudStudent
	{
		public string Id { get; set; }
		public string Name { get; set; } = null!;
		public string Surname { get; set; } = null!;
		public string Email { get; set; } = null!;
		public string FathersName { get; set; } = null!;
		public DateTime BirthDate { get; set; }
		//public byte Gender { get; set; }
		public string Fin { get; set; } = null!;

		//public double AverageGrade { get; set; }

		//public string? Address { get; set; }
		public string? Country { get; set; }
		public string? City { get; set; }

		public List<string> PhoneNumbers { get; set; }
		public List<string> Courses { get; set; }



		public List<string> Groups { get; set; }
		public string? District { get; set; }
		public string? StreetAddress { get; set; }
		public int HouseNo { get; set; }
		public int ZipCode { get; set; }

		public int HomeNumber { get; set; }

		public double? AverageGrade { get; set; }

		//  public int AddressId { get; set; }
		//public Address Address { get; set; }

		//public Country Country { get; set; }
		//public City City { get; set; }
		//public List<PhoneNumberViewModel> PhoneNumbers { get; set; }
		//public List<Course> Courses { get; set; }



		//public List<Group> Groups { get; set; } = null!;


		public int Status { get; set; }

		//public GraduatedStatus? GraduatedStatus { get; set; }

		//public LeftStatus? LeftStatus { get; set; }

		//public StoppedStatus? StoppedStatus { get; set; }

	}
}
