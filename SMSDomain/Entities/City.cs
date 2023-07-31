using SMSDomain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMSDomain.Entities
{
    public class City : BaseAuditableEntity
    {
        public ICollection<Address> Addresses { get; set; } = null!;
        public Country Country { get; set; } = null!;
        public int CountryId { get; set; }
        public string Name { get; set; } = null!;
    }
}
