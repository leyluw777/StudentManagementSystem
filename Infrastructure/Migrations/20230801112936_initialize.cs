using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class initialize : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Application.Common.Interfaces.IApplicationDbContext.FinalExams",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UsedTechnologies = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExamDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MarkId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Application.Common.Interfaces.IApplicationDbContext.FinalExams", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Application.Common.Interfaces.IApplicationDbContext.GraduatedStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GraduatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Application.Common.Interfaces.IApplicationDbContext.GraduatedStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Application.Common.Interfaces.IApplicationDbContext.Groups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Application.Common.Interfaces.IApplicationDbContext.Groups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Application.Common.Interfaces.IApplicationDbContext.LeftStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LeftDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LeftMessage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Application.Common.Interfaces.IApplicationDbContext.LeftStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Application.Common.Interfaces.IApplicationDbContext.StoppedStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StoppedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StoppedMessage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApproximateStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Application.Common.Interfaces.IApplicationDbContext.StoppedStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Application.Common.Interfaces.IApplicationDbContext.Courses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JoinedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalModules = table.Column<int>(type: "int", nullable: false),
                    TotalHours = table.Column<int>(type: "int", nullable: false),
                    FinalExamId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Application.Common.Interfaces.IApplicationDbContext.Courses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Application.Common.Interfaces.IApplicationDbContext.Courses_Application.Common.Interfaces.IApplicationDbContext.FinalExams_F~",
                        column: x => x.FinalExamId,
                        principalTable: "Application.Common.Interfaces.IApplicationDbContext.FinalExams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    FathersName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Gender = table.Column<byte>(type: "tinyint", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fin = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JoinedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Coordinator_ActiveStatus = table.Column<bool>(type: "bit", nullable: true),
                    LastLoginDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AverageGrade = table.Column<double>(type: "float", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: true),
                    GraduatedStatusId = table.Column<int>(type: "int", nullable: true),
                    LeftStatusId = table.Column<int>(type: "int", nullable: true),
                    StoppedStatusId = table.Column<int>(type: "int", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Experience = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ActiveStatus = table.Column<bool>(type: "bit", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Application.Common.Interfaces.IApplicationDbContext.GraduatedStatuses_GraduatedStatusId",
                        column: x => x.GraduatedStatusId,
                        principalTable: "Application.Common.Interfaces.IApplicationDbContext.GraduatedStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Application.Common.Interfaces.IApplicationDbContext.LeftStatuses_LeftStatusId",
                        column: x => x.LeftStatusId,
                        principalTable: "Application.Common.Interfaces.IApplicationDbContext.LeftStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Application.Common.Interfaces.IApplicationDbContext.StoppedStatuses_StoppedStatusId",
                        column: x => x.StoppedStatusId,
                        principalTable: "Application.Common.Interfaces.IApplicationDbContext.StoppedStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Application.Common.Interfaces.IApplicationDbContext.Modules",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalHours = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Application.Common.Interfaces.IApplicationDbContext.Modules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Application.Common.Interfaces.IApplicationDbContext.Modules_Application.Common.Interfaces.IApplicationDbContext.Courses_Cour~",
                        column: x => x.CourseId,
                        principalTable: "Application.Common.Interfaces.IApplicationDbContext.Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Application.Common.Interfaces.IApplicationDbContext.Addresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TeacherId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CoordinatorId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    District = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StreetAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HouseNo = table.Column<int>(type: "int", nullable: false),
                    ZipCode = table.Column<int>(type: "int", nullable: false),
                    HomeNumber = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "Getutcdate()"),
                    CreatedBy = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Application.Common.Interfaces.IApplicationDbContext.Addresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Application.Common.Interfaces.IApplicationDbContext.Addresses_AspNetUsers_CoordinatorId",
                        column: x => x.CoordinatorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Application.Common.Interfaces.IApplicationDbContext.Addresses_AspNetUsers_StudentId",
                        column: x => x.StudentId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Application.Common.Interfaces.IApplicationDbContext.Addresses_AspNetUsers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Application.Common.Interfaces.IApplicationDbContext.Countries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StudentId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "Getutcdate()"),
                    CreatedBy = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Application.Common.Interfaces.IApplicationDbContext.Countries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Application.Common.Interfaces.IApplicationDbContext.Countries_AspNetUsers_StudentId",
                        column: x => x.StudentId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Application.Common.Interfaces.IApplicationDbContext.Marks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Points = table.Column<int>(type: "int", nullable: false),
                    MaxPoints = table.Column<float>(type: "real", nullable: false),
                    OverallGrade = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FinalExamId = table.Column<int>(type: "int", nullable: false),
                    StudentId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Application.Common.Interfaces.IApplicationDbContext.Marks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Application.Common.Interfaces.IApplicationDbContext.Marks_Application.Common.Interfaces.IApplicationDbContext.FinalExams_Fin~",
                        column: x => x.FinalExamId,
                        principalTable: "Application.Common.Interfaces.IApplicationDbContext.FinalExams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Application.Common.Interfaces.IApplicationDbContext.Marks_AspNetUsers_StudentId",
                        column: x => x.StudentId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Application.Common.Interfaces.IApplicationDbContext.PhoneNumbers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StudentId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TeacherId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CoordinatorId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Application.Common.Interfaces.IApplicationDbContext.PhoneNumbers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Application.Common.Interfaces.IApplicationDbContext.PhoneNumbers_AspNetUsers_CoordinatorId",
                        column: x => x.CoordinatorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Application.Common.Interfaces.IApplicationDbContext.PhoneNumbers_AspNetUsers_StudentId",
                        column: x => x.StudentId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Application.Common.Interfaces.IApplicationDbContext.PhoneNumbers_AspNetUsers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CoordinatorCourse",
                columns: table => new
                {
                    CoordinatorsId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CoursesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoordinatorCourse", x => new { x.CoordinatorsId, x.CoursesId });
                    table.ForeignKey(
                        name: "FK_CoordinatorCourse_Application.Common.Interfaces.IApplicationDbContext.Courses_CoursesId",
                        column: x => x.CoursesId,
                        principalTable: "Application.Common.Interfaces.IApplicationDbContext.Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CoordinatorCourse_AspNetUsers_CoordinatorsId",
                        column: x => x.CoordinatorsId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CourseStudent",
                columns: table => new
                {
                    CoursesId = table.Column<int>(type: "int", nullable: false),
                    UsersId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseStudent", x => new { x.CoursesId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_CourseStudent_Application.Common.Interfaces.IApplicationDbContext.Courses_CoursesId",
                        column: x => x.CoursesId,
                        principalTable: "Application.Common.Interfaces.IApplicationDbContext.Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseStudent_AspNetUsers_UsersId",
                        column: x => x.UsersId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CourseTeacher",
                columns: table => new
                {
                    CoursesId = table.Column<int>(type: "int", nullable: false),
                    TeachersId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseTeacher", x => new { x.CoursesId, x.TeachersId });
                    table.ForeignKey(
                        name: "FK_CourseTeacher_Application.Common.Interfaces.IApplicationDbContext.Courses_CoursesId",
                        column: x => x.CoursesId,
                        principalTable: "Application.Common.Interfaces.IApplicationDbContext.Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseTeacher_AspNetUsers_TeachersId",
                        column: x => x.TeachersId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GroupStudent",
                columns: table => new
                {
                    GroupsId = table.Column<int>(type: "int", nullable: false),
                    UsersId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupStudent", x => new { x.GroupsId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_GroupStudent_Application.Common.Interfaces.IApplicationDbContext.Groups_GroupsId",
                        column: x => x.GroupsId,
                        principalTable: "Application.Common.Interfaces.IApplicationDbContext.Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GroupStudent_AspNetUsers_UsersId",
                        column: x => x.UsersId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Application.Common.Interfaces.IApplicationDbContext.Lessons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModuleId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TopicsCovered = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LessonDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Application.Common.Interfaces.IApplicationDbContext.Lessons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Application.Common.Interfaces.IApplicationDbContext.Lessons_Application.Common.Interfaces.IApplicationDbContext.Modules_Modu~",
                        column: x => x.ModuleId,
                        principalTable: "Application.Common.Interfaces.IApplicationDbContext.Modules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Application.Common.Interfaces.IApplicationDbContext.Cities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountryId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StudentId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "Getutcdate()"),
                    CreatedBy = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Application.Common.Interfaces.IApplicationDbContext.Cities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Application.Common.Interfaces.IApplicationDbContext.Cities_Application.Common.Interfaces.IApplicationDbContext.Countries_Cou~",
                        column: x => x.CountryId,
                        principalTable: "Application.Common.Interfaces.IApplicationDbContext.Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Application.Common.Interfaces.IApplicationDbContext.Cities_AspNetUsers_StudentId",
                        column: x => x.StudentId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Application.Common.Interfaces.IApplicationDbContext.Assessments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AssessmentType = table.Column<int>(type: "int", nullable: false),
                    MarkId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Application.Common.Interfaces.IApplicationDbContext.Assessments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Application.Common.Interfaces.IApplicationDbContext.Assessments_Application.Common.Interfaces.IApplicationDbContext.Marks_Ma~",
                        column: x => x.MarkId,
                        principalTable: "Application.Common.Interfaces.IApplicationDbContext.Marks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Application.Common.Interfaces.IApplicationDbContext.Quizzes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModuleId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TopicsCovered = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QuizDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MarkId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Application.Common.Interfaces.IApplicationDbContext.Quizzes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Application.Common.Interfaces.IApplicationDbContext.Quizzes_Application.Common.Interfaces.IApplicationDbContext.Marks_MarkId",
                        column: x => x.MarkId,
                        principalTable: "Application.Common.Interfaces.IApplicationDbContext.Marks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Application.Common.Interfaces.IApplicationDbContext.Quizzes_Application.Common.Interfaces.IApplicationDbContext.Modules_Modu~",
                        column: x => x.ModuleId,
                        principalTable: "Application.Common.Interfaces.IApplicationDbContext.Modules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Application.Common.Interfaces.IApplicationDbContext.NumberPrefixes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PhoneNumberId = table.Column<int>(type: "int", nullable: false),
                    Prefix = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Application.Common.Interfaces.IApplicationDbContext.NumberPrefixes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Application.Common.Interfaces.IApplicationDbContext.NumberPrefixes_Application.Common.Interfaces.IApplicationDbContext.Phone~",
                        column: x => x.PhoneNumberId,
                        principalTable: "Application.Common.Interfaces.IApplicationDbContext.PhoneNumbers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Application.Common.Interfaces.IApplicationDbContext.Attendances",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LessonId = table.Column<int>(type: "int", nullable: false),
                    StudentId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SharedNotes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InternalNotes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    AttendanceDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Application.Common.Interfaces.IApplicationDbContext.Attendances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Application.Common.Interfaces.IApplicationDbContext.Attendances_Application.Common.Interfaces.IApplicationDbContext.Lessons_~",
                        column: x => x.LessonId,
                        principalTable: "Application.Common.Interfaces.IApplicationDbContext.Lessons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Application.Common.Interfaces.IApplicationDbContext.Attendances_AspNetUsers_StudentId",
                        column: x => x.StudentId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Application.Common.Interfaces.IApplicationDbContext.Homeworks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LessonId = table.Column<int>(type: "int", nullable: false),
                    HomeworkDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LessonName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FilesAttached = table.Column<bool>(type: "bit", nullable: false),
                    FilePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MarkId = table.Column<int>(type: "int", nullable: false),
                    Deadline = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Application.Common.Interfaces.IApplicationDbContext.Homeworks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Application.Common.Interfaces.IApplicationDbContext.Homeworks_Application.Common.Interfaces.IApplicationDbContext.Lessons_Le~",
                        column: x => x.LessonId,
                        principalTable: "Application.Common.Interfaces.IApplicationDbContext.Lessons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Application.Common.Interfaces.IApplicationDbContext.Homeworks_Application.Common.Interfaces.IApplicationDbContext.Marks_Mark~",
                        column: x => x.MarkId,
                        principalTable: "Application.Common.Interfaces.IApplicationDbContext.Marks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Application.Common.Interfaces.IApplicationDbContext.Addresses_CoordinatorId",
                table: "Application.Common.Interfaces.IApplicationDbContext.Addresses",
                column: "CoordinatorId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Application.Common.Interfaces.IApplicationDbContext.Addresses_StudentId",
                table: "Application.Common.Interfaces.IApplicationDbContext.Addresses",
                column: "StudentId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Application.Common.Interfaces.IApplicationDbContext.Addresses_TeacherId",
                table: "Application.Common.Interfaces.IApplicationDbContext.Addresses",
                column: "TeacherId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Application.Common.Interfaces.IApplicationDbContext.Assessments_MarkId",
                table: "Application.Common.Interfaces.IApplicationDbContext.Assessments",
                column: "MarkId");

            migrationBuilder.CreateIndex(
                name: "IX_Application.Common.Interfaces.IApplicationDbContext.Attendances_LessonId",
                table: "Application.Common.Interfaces.IApplicationDbContext.Attendances",
                column: "LessonId");

            migrationBuilder.CreateIndex(
                name: "IX_Application.Common.Interfaces.IApplicationDbContext.Attendances_StudentId",
                table: "Application.Common.Interfaces.IApplicationDbContext.Attendances",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Application.Common.Interfaces.IApplicationDbContext.Cities_CountryId",
                table: "Application.Common.Interfaces.IApplicationDbContext.Cities",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Application.Common.Interfaces.IApplicationDbContext.Cities_StudentId",
                table: "Application.Common.Interfaces.IApplicationDbContext.Cities",
                column: "StudentId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Application.Common.Interfaces.IApplicationDbContext.Countries_StudentId",
                table: "Application.Common.Interfaces.IApplicationDbContext.Countries",
                column: "StudentId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Application.Common.Interfaces.IApplicationDbContext.Courses_FinalExamId",
                table: "Application.Common.Interfaces.IApplicationDbContext.Courses",
                column: "FinalExamId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Application.Common.Interfaces.IApplicationDbContext.Homeworks_LessonId",
                table: "Application.Common.Interfaces.IApplicationDbContext.Homeworks",
                column: "LessonId");

            migrationBuilder.CreateIndex(
                name: "IX_Application.Common.Interfaces.IApplicationDbContext.Homeworks_MarkId",
                table: "Application.Common.Interfaces.IApplicationDbContext.Homeworks",
                column: "MarkId");

            migrationBuilder.CreateIndex(
                name: "IX_Application.Common.Interfaces.IApplicationDbContext.Lessons_ModuleId",
                table: "Application.Common.Interfaces.IApplicationDbContext.Lessons",
                column: "ModuleId");

            migrationBuilder.CreateIndex(
                name: "IX_Application.Common.Interfaces.IApplicationDbContext.Marks_FinalExamId",
                table: "Application.Common.Interfaces.IApplicationDbContext.Marks",
                column: "FinalExamId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Application.Common.Interfaces.IApplicationDbContext.Marks_StudentId",
                table: "Application.Common.Interfaces.IApplicationDbContext.Marks",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Application.Common.Interfaces.IApplicationDbContext.Modules_CourseId",
                table: "Application.Common.Interfaces.IApplicationDbContext.Modules",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Application.Common.Interfaces.IApplicationDbContext.NumberPrefixes_PhoneNumberId",
                table: "Application.Common.Interfaces.IApplicationDbContext.NumberPrefixes",
                column: "PhoneNumberId");

            migrationBuilder.CreateIndex(
                name: "IX_Application.Common.Interfaces.IApplicationDbContext.PhoneNumbers_CoordinatorId",
                table: "Application.Common.Interfaces.IApplicationDbContext.PhoneNumbers",
                column: "CoordinatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Application.Common.Interfaces.IApplicationDbContext.PhoneNumbers_StudentId",
                table: "Application.Common.Interfaces.IApplicationDbContext.PhoneNumbers",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Application.Common.Interfaces.IApplicationDbContext.PhoneNumbers_TeacherId",
                table: "Application.Common.Interfaces.IApplicationDbContext.PhoneNumbers",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_Application.Common.Interfaces.IApplicationDbContext.Quizzes_MarkId",
                table: "Application.Common.Interfaces.IApplicationDbContext.Quizzes",
                column: "MarkId");

            migrationBuilder.CreateIndex(
                name: "IX_Application.Common.Interfaces.IApplicationDbContext.Quizzes_ModuleId",
                table: "Application.Common.Interfaces.IApplicationDbContext.Quizzes",
                column: "ModuleId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_GraduatedStatusId",
                table: "AspNetUsers",
                column: "GraduatedStatusId",
                unique: true,
                filter: "[GraduatedStatusId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_LeftStatusId",
                table: "AspNetUsers",
                column: "LeftStatusId",
                unique: true,
                filter: "[LeftStatusId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_StoppedStatusId",
                table: "AspNetUsers",
                column: "StoppedStatusId",
                unique: true,
                filter: "[StoppedStatusId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CoordinatorCourse_CoursesId",
                table: "CoordinatorCourse",
                column: "CoursesId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseStudent_UsersId",
                table: "CourseStudent",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseTeacher_TeachersId",
                table: "CourseTeacher",
                column: "TeachersId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupStudent_UsersId",
                table: "GroupStudent",
                column: "UsersId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Application.Common.Interfaces.IApplicationDbContext.Addresses");

            migrationBuilder.DropTable(
                name: "Application.Common.Interfaces.IApplicationDbContext.Assessments");

            migrationBuilder.DropTable(
                name: "Application.Common.Interfaces.IApplicationDbContext.Attendances");

            migrationBuilder.DropTable(
                name: "Application.Common.Interfaces.IApplicationDbContext.Cities");

            migrationBuilder.DropTable(
                name: "Application.Common.Interfaces.IApplicationDbContext.Homeworks");

            migrationBuilder.DropTable(
                name: "Application.Common.Interfaces.IApplicationDbContext.NumberPrefixes");

            migrationBuilder.DropTable(
                name: "Application.Common.Interfaces.IApplicationDbContext.Quizzes");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "CoordinatorCourse");

            migrationBuilder.DropTable(
                name: "CourseStudent");

            migrationBuilder.DropTable(
                name: "CourseTeacher");

            migrationBuilder.DropTable(
                name: "GroupStudent");

            migrationBuilder.DropTable(
                name: "Application.Common.Interfaces.IApplicationDbContext.Countries");

            migrationBuilder.DropTable(
                name: "Application.Common.Interfaces.IApplicationDbContext.Lessons");

            migrationBuilder.DropTable(
                name: "Application.Common.Interfaces.IApplicationDbContext.PhoneNumbers");

            migrationBuilder.DropTable(
                name: "Application.Common.Interfaces.IApplicationDbContext.Marks");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Application.Common.Interfaces.IApplicationDbContext.Groups");

            migrationBuilder.DropTable(
                name: "Application.Common.Interfaces.IApplicationDbContext.Modules");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Application.Common.Interfaces.IApplicationDbContext.Courses");

            migrationBuilder.DropTable(
                name: "Application.Common.Interfaces.IApplicationDbContext.GraduatedStatuses");

            migrationBuilder.DropTable(
                name: "Application.Common.Interfaces.IApplicationDbContext.LeftStatuses");

            migrationBuilder.DropTable(
                name: "Application.Common.Interfaces.IApplicationDbContext.StoppedStatuses");

            migrationBuilder.DropTable(
                name: "Application.Common.Interfaces.IApplicationDbContext.FinalExams");
        }
    }
}
