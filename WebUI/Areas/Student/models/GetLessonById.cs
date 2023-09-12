namespace WebUI.Areas.Student.Models
{
	public class GetLessonById
	{
		public int Id { get; set; }
		public int? Module { get; set; }

		public string? Name { get; set; }

		public string? Group { get; set; }
		public string? TopicsCovered { get; set; }
		public string? Notes { get; set; }
		public DateTime LessonDate { get; set; }
		public DateTime StartTime { get; set; }
		public DateTime EndTime { get; set; }
	}
}
