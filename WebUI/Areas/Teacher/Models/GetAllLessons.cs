namespace WebUI.Areas.Teacher.Models
{
    public class GetAllLessons
    {
        public int Id { get; set; }
        public int? ModuleId { get; set; }
        public string Name { get; set; } = null!;
        public string? TopicsCovered { get; set; }
        public string? Notes { get; set; }
        public DateTime LessonDate { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int? GroupId { get; set; }
    }
}
