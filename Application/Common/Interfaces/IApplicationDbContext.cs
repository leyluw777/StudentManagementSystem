using Microsoft.EntityFrameworkCore;
using SMSDomain.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {

        DbSet<Address> Addresses { get; set; }
        DbSet<Assessment> Assessments { get; set; }
        DbSet<Attendance> Attendances { get; set; }
        DbSet<City> Cities { get; set; }
        DbSet<Coordinator> Coordinators { get; set; }
        DbSet<Country> Countries { get; set; }
        DbSet<Course> Courses { get; set; }
        DbSet<FinalExam> FinalExams { get; set; }
        DbSet<GraduatedStatus> GraduatedStatuses { get; set; }
        DbSet<Group> Groups { get; set; }
        DbSet<Homework> Homeworks { get; set; }
        DbSet<LeftStatus> LeftStatuses { get; set; }
        DbSet<Lesson> Lessons { get; set; }
        DbSet<Mark> Marks { get; set; }
        DbSet<Module> Modules { get; set; }
        DbSet<NumberPrefix> NumberPrefixes { get; set; }
        DbSet<PhoneNumber> PhoneNumbers { get; set; }
        DbSet<Quiz> Quizzes { get; set; }

        DbSet<StoppedStatus> StoppedStatuses { get; set; }
        DbSet<Student> Students { get; set; }
        DbSet<Teacher> Teachers { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
