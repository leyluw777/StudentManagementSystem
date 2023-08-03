using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class seeddata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Age", "BirthDate", "ConcurrencyStamp", "Email", "EmailConfirmed", "FathersName", "Fin", "Gender", "Image", "JoinedDate", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Surname", "TwoFactorEnabled", "UserName" },
                values: new object[] { "8cad6191-d152-4560-adb0-9a651a23c651", 0, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "7eb6f459-4571-49dc-b031-65be9267eb49", "johndoe@gmail.com", false, "Sam", "4xk7hk9", (byte)0, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, "John", null, null, null, null, false, "139b8e4d-989a-4e37-9b2d-35c72a282ca5", "Doe", false, null });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "AverageGrade", "GraduatedStatusId", "LastLoginDate", "LeftStatusId", "Status", "StoppedStatusId" },
                values: new object[] { "8cad6191-d152-4560-adb0-9a651a23c651", 0.0, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0, null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: "8cad6191-d152-4560-adb0-9a651a23c651");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8cad6191-d152-4560-adb0-9a651a23c651");
        }
    }
}
