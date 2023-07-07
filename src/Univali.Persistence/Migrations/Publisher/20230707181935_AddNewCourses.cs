using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Univali.Api.Migrations.Publisher
{
    /// <inheritdoc />
    public partial class AddNewCourses : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "CourseId", "Category", "Description", "Price", "PublisherId", "Title" },
                values: new object[,]
                {
                    { 4, "Operating Systems", "You've heard that Windows is the future of enterprise computing and you're looking for a way in.", 47.00m, 2, "Getting Started with Windows" },
                    { 5, "Backend", "In this course, Javascript Fundamentals, you’ll learn to work with data in your .NET applications.", 197.00m, 1, "Javascript Fundamentals" },
                    { 6, "Backend", "In this course, FrontEnd Fundamentals, you’ll learn to work with data in your .NET applications.", 197.00m, 1, "FrontEnd Fundamentals" },
                    { 7, "Backend", "In this course, C# Fundamentals, you’ll learn to work with data in your .NET applications.", 197.00m, 1, "C# Fundamentals" }
                });

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2023, 7, 7, 18, 19, 35, 40, DateTimeKind.Utc).AddTicks(7694));

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2023, 7, 7, 18, 19, 35, 40, DateTimeKind.Utc).AddTicks(7696));

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 3,
                column: "CreationDate",
                value: new DateTime(2023, 7, 7, 18, 19, 35, 40, DateTimeKind.Utc).AddTicks(7697));

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 4,
                column: "CreationDate",
                value: new DateTime(2023, 7, 7, 18, 19, 35, 40, DateTimeKind.Utc).AddTicks(7698));

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 5,
                column: "CreationDate",
                value: new DateTime(2023, 7, 7, 18, 19, 35, 40, DateTimeKind.Utc).AddTicks(7699));

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 6,
                column: "CreationDate",
                value: new DateTime(2023, 7, 7, 18, 19, 35, 40, DateTimeKind.Utc).AddTicks(7700));

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 1,
                column: "RegistrationDate",
                value: new DateTime(2023, 7, 7, 18, 19, 35, 40, DateTimeKind.Utc).AddTicks(7685));

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 2,
                column: "RegistrationDate",
                value: new DateTime(2023, 7, 7, 18, 19, 35, 40, DateTimeKind.Utc).AddTicks(7687));

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 3,
                column: "RegistrationDate",
                value: new DateTime(2023, 7, 7, 18, 19, 35, 40, DateTimeKind.Utc).AddTicks(7688));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 7);

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2023, 7, 7, 15, 46, 40, 302, DateTimeKind.Utc).AddTicks(7873));

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2023, 7, 7, 15, 46, 40, 302, DateTimeKind.Utc).AddTicks(7875));

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 3,
                column: "CreationDate",
                value: new DateTime(2023, 7, 7, 15, 46, 40, 302, DateTimeKind.Utc).AddTicks(7876));

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 4,
                column: "CreationDate",
                value: new DateTime(2023, 7, 7, 15, 46, 40, 302, DateTimeKind.Utc).AddTicks(7877));

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 5,
                column: "CreationDate",
                value: new DateTime(2023, 7, 7, 15, 46, 40, 302, DateTimeKind.Utc).AddTicks(7879));

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 6,
                column: "CreationDate",
                value: new DateTime(2023, 7, 7, 15, 46, 40, 302, DateTimeKind.Utc).AddTicks(7880));

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 1,
                column: "RegistrationDate",
                value: new DateTime(2023, 7, 7, 15, 46, 40, 302, DateTimeKind.Utc).AddTicks(7856));

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 2,
                column: "RegistrationDate",
                value: new DateTime(2023, 7, 7, 15, 46, 40, 302, DateTimeKind.Utc).AddTicks(7859));

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 3,
                column: "RegistrationDate",
                value: new DateTime(2023, 7, 7, 15, 46, 40, 302, DateTimeKind.Utc).AddTicks(7860));
        }
    }
}
