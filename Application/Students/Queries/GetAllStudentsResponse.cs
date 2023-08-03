using Application.Common.Mappings;
using SMSDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Students.Queries
{
    public class GetAllStudentsResponse //: IMapFrom<Student>
    {
        public List<StudentDto> Students { get; set; }
    }
}
