using Application.Common.Interfaces;
using Infrastructure.Persistence.Interceptors;
using MediatR;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SMSDomain.Entities;
using SMSDomain.Identity;

using System.Reflection;


namespace Infrastructure.Persistence
{
    public class AppDbContext : IdentityDbContext<AppUser>, IApplicationDbContext
{

    private readonly AuditableEntitySaveChangesInterceptor _interceptor;

        public AppDbContext(DbContextOptions options, AuditableEntitySaveChangesInterceptor interceptor) : base(options)
        {
           
            _interceptor = interceptor;
        }

        DbSet<Address> IApplicationDbContext.Addresses {get; set; }
        DbSet<Assessment> IApplicationDbContext.Assessments {get; set; }
        DbSet<Attendance> IApplicationDbContext.Attendances {get; set; }
        DbSet<City> IApplicationDbContext.Cities {get; set; }
        DbSet<Coordinator> IApplicationDbContext.Coordinators {get; set; }
        DbSet<Country> IApplicationDbContext.Countries {get; set; }
        DbSet<Course> IApplicationDbContext.Courses {get; set; }
        DbSet<FinalExam> IApplicationDbContext.FinalExams {get; set; }
        DbSet<GraduatedStatus> IApplicationDbContext.GraduatedStatuses {get; set; }
        DbSet<Group> IApplicationDbContext.Groups {get; set; }
        DbSet<Homework> IApplicationDbContext.Homeworks {get; set; }
        DbSet<LeftStatus> IApplicationDbContext.LeftStatuses {get; set; }
        DbSet<Lesson> IApplicationDbContext.Lessons {get; set; }
        DbSet<Mark> IApplicationDbContext.Marks {get; set; }
        DbSet<SMSDomain.Entities.Module> IApplicationDbContext.Modules {get; set; }
        DbSet<NumberPrefix> IApplicationDbContext.NumberPrefixes {get; set; }
        DbSet<PhoneNumber> IApplicationDbContext.PhoneNumbers {get; set; }
        DbSet<Quiz> IApplicationDbContext.Quizzes {get; set; }
        DbSet<StoppedStatus> IApplicationDbContext.StoppedStatuses {get; set; }
        DbSet<Student> IApplicationDbContext.Students {get; set; }
        DbSet<Teacher> IApplicationDbContext.Teachers {get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="AppDbContext"/> class.
        /// </summary>
        /// <param name="options">The options for configuring the database context.</param>
        /// <param name="interceptor">The interceptor for automatically updating auditable entities.</param>
        /// <param name="mediator">The mediator for handling events and commands.</param>
        //public AppDbContext(
        //                DbContextOptions<AppDbContext> options,
        //                AuditableEntitySaveChangesInterceptor interceptor
        //                )
        //                : base(options)
        //{
        //    _interceptor = interceptor;
           
        //}


        /// <summary>
        /// Configures the model for the database context.
        /// </summary>
        /// <param name="builder">The model builder instance to be configured.</param>
        protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(builder);
    }

        /// <summary>
        /// Configures the options for the database context.
        /// </summary>
        /// <param name="optionsBuilder">The options builder used to configure the options.</param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.AddInterceptors(_interceptor);
    }

    /// <summary>
    /// Saves all changes made in this context to the database asynchronously.
    /// </summary>
    /// <param name="cancellationToken">A <see cref="CancellationToken"/> to observe while waiting for the task to complete.</param>
    /// <returns>A task representing the asynchronous save operation. The task result contains the number of state entries written to the database.</returns>
    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await base.SaveChangesAsync(cancellationToken);
    }

        Task<int> IApplicationDbContext.SaveChangesAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
