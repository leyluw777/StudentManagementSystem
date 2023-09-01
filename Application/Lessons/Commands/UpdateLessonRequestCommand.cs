using Application.Common.Results;
using MediatR;
using SMSDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Lessons.Commands
{
    public class UpdateLessonRequestCommand: IRequest< IDataResult<UpdateLessonRequestCommand>>
    {
        public int Id { get; set; } 
        public int? Module { get; set; }

        public string? Name { get; set; } 

        public string? Group { get; set; }
        public string? TopicsCovered { get; set; }
        public string? Notes { get; set; }
        public DateTime LessonDate { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }


        //public List<Homework>? Homeworks { get; set; }
        public List<Attendance>? Attendances { get; set; }
    }
}
