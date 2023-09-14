namespace WebUI.Areas.Teacher.Models
{
    public class Student
    {

        public string Id { get; set; }
        public string Name { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string FathersName { get; set; } = null!;
        public int? Age { get; set; }
        public DateTime? BirthDate { get; set; }
        public byte? Gender { get; set; }
        public string? Image { get; set; }
        public string Fin { get; set; } = null!;
    }
}
