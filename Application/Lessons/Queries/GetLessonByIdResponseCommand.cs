using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Lessons.Queries
{
    public class GetLessonByIdResponseCommand
    {
        public int Id { get; set; }
        public int? Module { get; set; }

        public string? Name { get; set; } = null!;

        public string? Group { get; set; }
        public string? TopicsCovered { get; set; }
        public string? Notes { get; set; }
        public DateTime LessonDate { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
