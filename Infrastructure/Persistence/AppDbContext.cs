using Application.Common.Interfaces;
using Infrastructure.Persistence.Interceptors;
using Infrastructure.SeedData;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using SMSDomain.Identity;
using System.Reflection;


namespace Infrastructure.Persistence
{
	public class AppDbContext : IdentityDbContext<AppUser>, IApplicationDbContext
{

    private readonly AuditableEntitySaveChangesInterceptor _interceptor;
        private readonly UserManager<AppUser> _userManager;


        public AppDbContext(DbContextOptions options, AuditableEntitySaveChangesInterceptor interceptor) : base(options)
        {
            _interceptor = interceptor;         
        }

        public DbSet<Address>  Addresses {get; set; }
        public DbSet<Assessment>  Assessments {get; set; }
        public DbSet<Attendance>  Attendances {get; set; }
        public DbSet<City>  Cities {get; set; }
        public DbSet<Coordinator>  Coordinators {get; set; }
        public DbSet<Country>  Countries {get; set; }
        public DbSet<Course>  Courses {get; set; }
        public DbSet<FinalExam>  FinalExams {get; set; }
        public DbSet<GraduatedStatus>  GraduatedStatuses {get; set; }
        public DbSet<Group>  Groups {get; set; }
        public DbSet<Homework>  Homeworks {get; set; }
        public DbSet<LeftStatus>  LeftStatuses {get; set; }
        public DbSet<Lesson>  Lessons {get; set; }
        public DbSet<Mark>  Marks {get; set; }
        public DbSet<SMSDomain.Entities.Module> Modules { get; set; }
        public DbSet<PhoneNumber> PhoneNumbers {get; set; }
        public DbSet<Quiz>  Quizzes {get; set; }
        public DbSet<StoppedStatus>  StoppedStatuses {get; set; }
        public DbSet<Student>  Students {get; set; }
        public DbSet<Teacher>  Teachers {get; set; }

        public DbSet<CourseStudent> CourseStudent { get; set ; }
        public DbSet<GroupStudent> GroupStudent { get; set; }
        public DbSet<GroupTeacher> GroupTeacher { get; set; }
        public DbSet<FirstLogin> FirstLogins { get; set; }
        public DbSet<CourseTeacher> CourseTeacher { get; set; }


        //public void SeedRoles()
        //{
        //    if (!Roles.Any())
        //    {
        //        var roles = new List<AppRole>
        //{
        //    new AppRole { Name = "Admin", NormalizedName = "ADMIN" },
        //    new AppRole { Name = "Student", NormalizedName = "STUDENT" },
        //    new AppRole { Name = "Teacher", NormalizedName = "TEACHER" },
        //    new AppRole { Name = "Coordinator", NormalizedName = "COORDINATOR" }

        //    // Add more roles as needed
        //};
        //        foreach (var role in roles)
        //        {
        //            _roleManager.CreateAsync(role).Wait();
        //        }
        //    }
        //}

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
                              .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Mark>().HasOne(x => x.FinalExam)
                                  .WithOne(x => x.Mark)
                                  .HasForeignKey<Mark>(y => y.FinalExamId)
                              .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Student>().HasOne(x => x.GraduatedStatus)
                                .WithOne(x => x.Student)
                                .HasForeignKey<Student>(y => y.GraduatedStatusId)
                              .OnDelete(DeleteBehavior.Restrict)
                              .IsRequired(false);
            builder.Entity<Student>().HasOne(x => x.LeftStatus)
                               .WithOne(x => x.Student)
                               .HasForeignKey<Student>(y => y.LeftStatusId)
                              .OnDelete(DeleteBehavior.Restrict)
                              .IsRequired(false);
            builder.Entity<Address>().HasOne(x => x.Student)
                              .WithOne(x => x.Address)
                              .HasForeignKey<Address>(y => y.StudentId)
                              .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Student>().HasOne(x => x.Country)
                         .WithMany(x => x.Students)
                         .HasForeignKey(y => y.CountryId)
                              .OnDelete(DeleteBehavior.Restrict);


            builder.Entity<Student>().HasOne(x => x.City)
                     .WithMany(x => x.Students)
                     .HasForeignKey(y => y.CityId)
                          .OnDelete(DeleteBehavior.Restrict);


            builder.Entity<Address>().HasOne(x => x.Teacher)
                              .WithOne(x => x.Address)
                              .HasForeignKey<Address>(y => y.TeacherId)
                              .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Address>().HasOne(x => x.Coordinator)
                              .WithOne(x => x.Address)
                              .HasForeignKey<Address>(y => y.CoordinatorId)
                              .OnDelete(DeleteBehavior.Restrict)
                              .IsRequired(false);
            builder.Entity<Student>().HasOne(x => x.StoppedStatus)
                               .WithOne(x => x.Student)
                               .HasForeignKey<Student>(y => y.StoppedStatusId)
                              .OnDelete(DeleteBehavior.Restrict)
                              .IsRequired(false); 
            builder.Entity<Student>(x => x.ToTable("Students"));
            builder.Entity<Student>().Property(x => x.LastLoginDate).IsRequired(false);
            


            builder.Entity<Teacher>(x => x.ToTable("Teachers"));
            builder.Entity<Coordinator>(x => x.ToTable("Coordinators"));
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
               .OnDelete(DeleteBehavior.Restrict);
            

            builder.Entity<PhoneNumber>().HasOne(x => x.Student)
     .WithMany(h => h.PhoneNumbers)
     .HasForeignKey(x => x.StudentId)
     .OnDelete(DeleteBehavior.Restrict)
  .IsRequired(false);


            builder.Entity<PhoneNumber>().HasOne(x => x.Teacher)
  .WithMany(h => h.PhoneNumbers)
  .HasForeignKey(x => x.TeacherId)
  .OnDelete(DeleteBehavior.Restrict)
  .IsRequired(false);
            builder.Entity<PhoneNumber>().HasOne(x => x.Coordinator)
  .WithMany(h => h.PhoneNumbers)
  .HasForeignKey(x => x.CoordinatorId)
  .OnDelete(DeleteBehavior.Restrict)
  .IsRequired(false);

            builder.Entity<CourseStudent>()
                .HasKey(cs => new { cs.CourseId, cs.StudentId });

            // Configure the relationship between Course and CourseStudent
            builder.Entity<CourseStudent>()
                .HasOne(cs => cs.Course)
                .WithMany(c => c.CourseStudents)
                .HasForeignKey(cs => cs.CourseId);

            // Configure the relationship between Student and CourseStudent
            builder.Entity<CourseStudent>()
                .HasOne(cs => cs.Student)
                .WithMany(s => s.CourseStudents)
                .HasForeignKey(cs => cs.StudentId);


            builder.Entity<CourseTeacher>()
    .HasKey(cs => new { cs.CourseId, cs.TeacherId });

            // Configure the relationship between Course and CourseStudent
            builder.Entity<CourseTeacher>()
                .HasOne(cs => cs.Course)
                .WithMany(c => c.courseTeachers)
                .HasForeignKey(cs => cs.CourseId);

            // Configure the relationship between Student and CourseStudent
            builder.Entity<CourseTeacher>()
                .HasOne(cs => cs.Teacher)
                .WithMany(s => s.courseTeachers)
                .HasForeignKey(cs => cs.TeacherId);




            builder.Entity<GroupStudent>()
                .HasKey(cs => new { cs.GroupId, cs.StudentId });

            // Configure the relationship between Course and CourseStudent
            builder.Entity<GroupStudent>()
                .HasOne(cs => cs.Group)
                .WithMany(c => c.GroupStudents)
                .HasForeignKey(cs => cs.GroupId);

            // Configure the relationship between Student and CourseStudent
            builder.Entity<GroupStudent>()
                .HasOne(cs => cs.Student)
                .WithMany(s => s.GroupStudents)
                .HasForeignKey(cs => cs.StudentId);



            //builder.Entity<Address>().HasOne(h => h.Country)  //burda
            //  .WithMany(x => x.Address)
            //  .HasForeignKey(h => h.CountryId)
            //  .IsRequired(true);


            //builder.Entity<Address>().HasOne(h => h.City)
            //   .WithMany(x => x.Addresses)
            //   .HasForeignKey(h => h.CityId)

            //   .IsRequired(true);

            //            builder.Entity<Student>().HasData(
            //new Student
            //{
            //    Name = "John",
            //    Surname = "Doe",
            //    FathersName = "Sam",
            //    Email = "johndoe@gmail.com",
            //    Fin = "4xk7hk9",
            //    GraduatedStatusId = null,
            //    LeftStatusId = null,
            //    StoppedStatusId = null

            //});

           
        builder.Entity<Group>().HasData(
           new Group
           {
               Id = 1,
              Name = "FRONT102",
              Description = "New front-end group",
              StartDate  = new DateTime(2019, 05, 09, 09, 15, 00),
              EndDate = new DateTime(2020, 05, 09, 09, 15, 00)

           });


            builder.Entity<AppRole>().HasData(
                      new AppRole { Name = "Admin", NormalizedName = "ADMIN" },
                      new AppRole { Name = "Student", NormalizedName = "STUDENT" },
                      new AppRole { Name = "Teacher", NormalizedName = "TEACHER" },
                      new AppRole { Name = "Coordinator", NormalizedName = "COORDINATOR" }
              );

            builder.AddCountriesData();
            builder.AddCitiesData();
            builder.AddCoursesData();
            builder.AddModulesData();
            builder.AddGroupsData();

        




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

    }
}
