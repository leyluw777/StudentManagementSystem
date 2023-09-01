namespace WebUI.Areas.Admin.Models
{
    public class GetAllStudentsByGroup
    {
        public string Id { get; set; }
        public string Name { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public string FathersName { get; set; } = null!;
     

        //  public int AddressId { get; set; }
    
        //   public List<Attendance>? Attendances { get; set; }

        public List<string> Groups { get; set; } = null!;


    }
}
