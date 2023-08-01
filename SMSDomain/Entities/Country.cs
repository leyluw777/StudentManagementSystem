using SMSDomain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMSDomain.Entities
{
    public class Country : BaseAuditableEntity
    {
        public string Name { get; set; } = null!;
        public Student Student { get; set; }
        public string StudentId { get; set; }
       
       // public List<Address> Address { get; set; } = null!;
        public List<City> Cities { get; set; } 
    }
}
