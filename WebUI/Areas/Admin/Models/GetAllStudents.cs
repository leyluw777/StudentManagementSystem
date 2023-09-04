namespace WebUI.Areas.Admin.Models
{
	public class GetAllStudents
	{
		public string Id { get; set; } 
		public string Name { get; set; } = null!;
		public string Surname { get; set; } = null!;
		public string Fin { get; set; } = null!;
		public string FathersName { get; set; } = null!;
		public string Email { get; set; } = null!;
		public double AverageGrade { get; set; }
		public int Status { get; set; }

		public string Group { get; set; } = null!;
	}
}
