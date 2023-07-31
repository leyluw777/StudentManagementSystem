﻿using SMSDomain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMSDomain.Entities
{
    public class Course : BaseAuditableEntity
    {
        public string Name { get; set; }
        public DateTime JoinedDate { get; set; }
        public int TotalModules { get; set; }
        public int TotalHours { get; set; }
        public int FinalExamId { get;set; }
        public FinalExam FinalExam { get; set; } 
        public ICollection<Student> Users { get; set; } = null!;
        public ICollection<Module> Modules { get; set; }
        public ICollection<Teacher> Teachers { get; set; }

        public ICollection<Coordinator> Coordinators { get; set; }

    }
}