using SMSDomain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMSDomain.Entities
{
    public class Country : BaseAuditableEntity
    {
        public string Name { get; set; } = null!;
        public ICollection<Address> Address { get; set; } = null!;
        public ICollection<City> Cities { get; set; } 
    }
}
