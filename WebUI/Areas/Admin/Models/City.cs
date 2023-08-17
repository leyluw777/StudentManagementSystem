using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebUI.Areas.Admin.Models
{
    public class City 
    {
		public int Id { get; set; }
		//[NotMapped]
		//  public ICollection<Address> Addresses { get; set; } = null!;
		public Country? Country { get; set; } 
        public int? CountryId { get; set; }
        public string Name { get; set; } = null!;
     
       
    }
}
