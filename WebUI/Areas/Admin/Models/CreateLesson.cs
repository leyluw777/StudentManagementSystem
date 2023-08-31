namespace WebUI.Areas.Admin.Models
{
    public class CreateLesson
    {
      
        public int? Module { get; set; }

        public string Name { get; set; } = null!;

        public string? Group { get; set; }
        //public string? TopicsCovered { get; set; }
        //public string? Notes { get; set; }
        //public DateTime LessonDate { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
