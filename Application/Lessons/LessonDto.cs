using Application.Common.Mappings;
using System;
using SMSDomain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Lessons
{
	public class LessonDto : IMapFrom<SMSDomain.Entities.Lesson>
	{
		public int ModuleId { get; set; }
		public string Name { get; set; } = null!;
		public string? TopicsCovered { get; set; }
		public string? Notes { get; set; }
		public DateTime LessonDate { get; set; }
		public DateTime StartTime { get; set; }
		public DateTime EndTime { get; set; }
        public int GroupId { get; set; }

        //public List<Homework> Homeworks { get; set; }
        //public List<Attendance> Attendances { get; set; }
    }
}
