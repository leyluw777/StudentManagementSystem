namespace WebUI.Areas.Admin.Models
{
    public class Attendance
    {
        public Lesson? Lesson { get; set; }
        public int? LessonId { get; set; }

        public Student? Student { get; set; }
        public string? StudentId { get; set; }
        public string? SharedNotes { get; set; }
        public string? InternalNotes { get; set; }
        public bool Status { get; set; }
        public DateTime AttendanceDate { get; set; }
    }
}
