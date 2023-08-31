using SMSDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Students.Queries
{
	public class GetStudentsByGroupResponse
	{
		public List<Student> GroupStudents { get; set; }
	}
}
