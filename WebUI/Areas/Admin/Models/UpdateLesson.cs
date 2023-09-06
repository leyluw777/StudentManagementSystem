namespace WebUI.Areas.Admin.Models
{
    public class UpdateLesson
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

        public List<Attendance>? Attendances { get; set; }

        //public List<Homework>? Homeworks { get; set; }
        //public List<Attendance>? Attendances { get; set; }
    }
}
