using Application.Students.Commands;
using SMSDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Students.Queries
{
	public class GetNewStudentsResponse
	{
		public List<FirstLogin>? NewStudents { get; set; }
	}
}
