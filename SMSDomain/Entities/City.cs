using Microsoft.EntityFrameworkCore;
using SMSDomain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMSDomain.Entities
{
    public class City : BaseAuditableEntity
    {
        //[NotMapped]
      //  public ICollection<Address> Addresses { get; set; } = null!;
        public Country? Country { get; set; } 
        public int? CountryId { get; set; }
        public string Name { get; set; } = null!;
        public List<Student>? Students { get; set; }
       
    }
}
