using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Lesson.Queries
{
	public class GetAllLessonsResponseQuery
	{
		public List<SMSDomain.Entities.Lesson> Lessons { get; set; }
	}
}
