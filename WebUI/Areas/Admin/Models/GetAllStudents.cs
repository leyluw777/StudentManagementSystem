namespace WebUI.Areas.Admin.Models
{
	public class GetAllStudents
	{
		public string Id { get; set; }
		public string Name { get; set; }  
		public string Surname { get; set; }
		public string Fin { get; set; }
		public string FathersName { get; set; } 
		public string Email { get; set; }
		public double AverageGrade { get; set; }
		public int Status { get; set; }

		public string Group { get; set; }
	}
}
