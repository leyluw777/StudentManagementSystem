using Application.Common.Interfaces;
using Infrastructure.Persistence.Interceptors;
using MediatR;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SMSDomain.Entities;
using SMSDomain.Identity;

using System.Reflection;
using System.Reflection.Emit;


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
            builder.Entity<Course>().HasOne(x => x.FinalExam)
                                  .WithOne(x => x.Course)
                                  .HasForeignKey<Course>(y => y.FinalExamId)
                              .OnDelete(DeleteBehavior.Restrict)

                                  .IsRequired();
            builder.Entity<Mark>().HasOne(x => x.FinalExam)
                                  .WithOne(x => x.Mark)
                                  .HasForeignKey<Mark>(y => y.FinalExamId)
                              .OnDelete(DeleteBehavior.Restrict)

                                  .IsRequired();
            builder.Entity<Student>().HasOne(x => x.GraduatedStatus)
                                .WithOne(x => x.Student)
                                .HasForeignKey<Student>(y => y.GraduatedStatusId)
                              .OnDelete(DeleteBehavior.Restrict)

                                .IsRequired();
            builder.Entity<Student>().HasOne(x => x.LeftStatus)
                               .WithOne(x => x.Student)
                               .HasForeignKey<Student>(y => y.LeftStatusId)
                              .OnDelete(DeleteBehavior.Restrict)

                               .IsRequired();
            builder.Entity<Address>().HasOne(x => x.Student)
                              .WithOne(x => x.Address)
                              .HasForeignKey<Address>(y => y.StudentId)
                              .OnDelete(DeleteBehavior.Restrict)
                              .IsRequired();
            builder.Entity<City>().HasOne(x => x.Student)
                         .WithOne(x => x.City)
                         .HasForeignKey<City>(y => y.StudentId)
                              .OnDelete(DeleteBehavior.Restrict)

                         .IsRequired();
            builder.Entity<Country>().HasOne(x => x.Student)
                         .WithOne(x => x.Country)
                         .HasForeignKey<Country>(y => y.StudentId)
                              .OnDelete(DeleteBehavior.Restrict)

                         .IsRequired();
            builder.Entity<Address>().HasOne(x => x.Teacher)
                              .WithOne(x => x.Address)
                              .HasForeignKey<Address>(y => y.TeacherId)
                              .OnDelete(DeleteBehavior.Restrict)
                              .IsRequired();
            builder.Entity<Address>().HasOne(x => x.Coordinator)
                              .WithOne(x => x.Address)
                              .HasForeignKey<Address>(y => y.CoordinatorId)
                              .OnDelete(DeleteBehavior.Restrict);
            builder.Entity<Student>().HasOne(x => x.StoppedStatus)
                               .WithOne(x => x.Student)
                               .HasForeignKey<Student>(y => y.StoppedStatusId)
                              .OnDelete(DeleteBehavior.Restrict)

                               .IsRequired();
            //builder.Entity<Country>()
            //    .HasOne(c => c.Address)
            //    .WithMany()
            //    .OnDelete(deleteBehavior:DeleteBehavior.Restrict);
            //builder.Entity<City>()
            //       .HasOne(s => s.Addresses)
            //       .WithMany()
            //       .OnDelete(deleteBehavior: DeleteBehavior.Restrict);
            builder.Entity<City>().HasOne(x => x.Country)
               .WithMany(h => h.Cities)
               .HasForeignKey(x => x.CountryId)
               .OnDelete(DeleteBehavior.Restrict)
               .IsRequired();

            builder.Entity<PhoneNumber>().HasOne(x => x.Student)
     .WithMany(h => h.PhoneNumbers)
     .HasForeignKey(x => x.StudentId)
     .OnDelete(DeleteBehavior.Restrict)
     .IsRequired();
            builder.Entity<PhoneNumber>().HasOne(x => x.Teacher)
  .WithMany(h => h.PhoneNumbers)
  .HasForeignKey(x => x.TeacherId)
  .OnDelete(DeleteBehavior.Restrict)
  .IsRequired();
            builder.Entity<PhoneNumber>().HasOne(x => x.Coordinator)
  .WithMany(h => h.PhoneNumbers)
  .HasForeignKey(x => x.CoordinatorId)
  .OnDelete(DeleteBehavior.Restrict)
  .IsRequired();
            //builder.Entity<Address>().HasOne(h => h.Country)  //burda
            //  .WithMany(x => x.Address)
            //  .HasForeignKey(h => h.CountryId)
            //  .IsRequired(true);


            //builder.Entity<Address>().HasOne(h => h.City)
            //   .WithMany(x => x.Addresses)
            //   .HasForeignKey(h => h.CityId)

            //   .IsRequired(true);
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
