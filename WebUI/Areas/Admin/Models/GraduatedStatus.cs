//using SMSDomain.Common;
//using System;
//using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations.Schema;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace SMSDomain.Entities
//{
//    public class GraduatedStatus : BaseAuditableEntity
//    {
//        public DateTime GraduatedDate { get; set; }
//        public Student Student { get; set; }
       


//        // this is final grade, it is counted by using other marks in total. 
//        // Do we need to add it to db ? 
//        [NotMapped]
//        public string OverallGrade { get; set; } = null!; 
//    }
//}
