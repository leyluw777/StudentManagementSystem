using SMSDomain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMSDomain.Entities
{
    public class NumberPrefix : BaseAuditableEntity
    {
        public PhoneNumber PhoneNumber { get; set; }
        public int PhoneNumberId { get; set; }
        public string Prefix { get; set; }
    }
}
