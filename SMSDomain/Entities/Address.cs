using SMSDomain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMSDomain.Entities
{
    public class Address : BaseAuditableEntity
    {
/*        public Student Student { get; set; } = null!;
        public Guid StudentId { get; set; }*/

        //public Teacher Teacher { get; set; }
        //public Guid TeacherId { get; set; }
        public Coordinator Coordinator { get; set; }
        public Guid CoordinatorId { get; set; }

        public Country Country { get; set; } //burda
        public int CountryId { get; set; } 

        public City City { get; set; }
        public int CityId { get; set; } 
        public string District { get; set; }
        public string StreetAddress { get; set; }
        public int HouseNo { get; set; }
        public int ZipCode { get; set; }

        public int HomeNumber { get; set; }

    }
}
