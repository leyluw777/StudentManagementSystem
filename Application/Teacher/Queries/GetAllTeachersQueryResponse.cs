using Application.Common.Mappings;
using SMSDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Teacher.Queries
{
    public class GetAllTeachersQueryResponse //: IMapFrom<Student>
    {
        public List<TeacherDto> Teachers { get; set; }
    }
}
