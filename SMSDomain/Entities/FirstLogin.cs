using SMSDomain.Common;
using SMSDomain.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMSDomain.Entities
{
    public class FirstLogin : BaseEntity
    {
        public AppUser User { get; set; }
        public string UserId { get; set; }

        public string Name { get; set; }
        public string Surname { get; set; }
        public string FathersName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
