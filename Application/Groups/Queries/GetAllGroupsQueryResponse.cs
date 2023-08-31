using SMSDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Groups.Queries
{
    public class GetAllGroupsQueryResponse
    {
       public List<Group> Groups { get; set; }
    }
}
