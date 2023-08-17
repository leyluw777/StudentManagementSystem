using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity;
using SMSDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMSDomain.Identity
{
    public class AppUser : IdentityUser
    {
        public string Name { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string FathersName { get; set; } = null!;
        public int? Age { get; set; }
        public DateTime? BirthDate { get; set; }
        public byte? Gender { get; set; }
        public string? Image { get; set; }
        public string Fin { get; set; } = null!;
        public DateTime? JoinedDate { get; set; }
 
        public FirstLogin? FirstLogin { get; set; }
        
       
    }
}
