using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebUI.Areas.Admin.Models;
    public class Country { 
        public int Id { get; set; }
        public string Name { get; set; }
    
       // public List<Address> Address { get; set; } = null!;
       public List<City> Cities { get; set; }
    }

