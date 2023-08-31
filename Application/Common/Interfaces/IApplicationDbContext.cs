using Microsoft.EntityFrameworkCore;
using SMSDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Assessment> Assessments { get; set; }
        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Coordinator> Coordinators { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<FinalExam> FinalExams { get; set; }
        public DbSet<GraduatedStatus> GraduatedStatuses { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Homework> Homeworks { get; set; }
        public DbSet<LeftStatus> LeftStatuses { get; set; }
        public DbSet<SMSDomain.Entities.Lesson> Lessons { get; set; }
        public DbSet<Mark> Marks { get; set; }
        public DbSet<SMSDomain.Entities.Module> Modules { get; set; }
        public DbSet<PhoneNumber> PhoneNumbers { get; set; }
        public DbSet<Quiz> Quizzes { get; set; }
        public DbSet<StoppedStatus> StoppedStatuses { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<SMSDomain.Entities.Teacher> Teachers { get; set; }
        public DbSet<CourseTeacher> CourseTeacher { get; set; }
        public DbSet<CourseStudent> CourseStudent { get; set; }
        public DbSet<GroupStudent> GroupStudent { get; set; }
        public DbSet<FirstLogin> FirstLogins { get; set; }
      
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
