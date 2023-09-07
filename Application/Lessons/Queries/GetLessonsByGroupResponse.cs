using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Lessons.Queries
{
	public class GetLessonsByGroupResponse
	{

		public List<SMSDomain.Entities.Lesson>? Lessons { get; set; }
	}
}
