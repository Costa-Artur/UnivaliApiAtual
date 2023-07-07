using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Univali.Api.Migrations.Publisher
{
    /// <inheritdoc />
    public partial class ExtensionsAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    AuthorId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(80)", maxLength: 80, nullable: false),
                    CPF = table.Column<string>(type: "character(11)", fixedLength: true, maxLength: 11, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.AuthorId);
                });

            migrationBuilder.CreateTable(
                name: "Modules",
                columns: table => new
                {
                    ModuleId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modules", x => x.ModuleId);
                });

            migrationBuilder.CreateTable(
                name: "Publishers",
                columns: table => new
                {
                    PublisherId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(80)", maxLength: 80, nullable: false),
                    CNPJ = table.Column<string>(type: "character(14)", fixedLength: true, maxLength: 14, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publishers", x => x.PublisherId);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    StudentId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(80)", maxLength: 80, nullable: false),
                    CPF = table.Column<string>(type: "character(11)", fixedLength: true, maxLength: 11, nullable: false),
                    Age = table.Column<int>(type: "integer", fixedLength: true, maxLength: 3, nullable: false),
                    RegistrationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.StudentId);
                });

            migrationBuilder.CreateTable(
                name: "Lessons",
                columns: table => new
                {
                    LessonId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    ModuleId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lessons", x => x.LessonId);
                    table.ForeignKey(
                        name: "FK_Lessons_Modules_ModuleId",
                        column: x => x.ModuleId,
                        principalTable: "Modules",
                        principalColumn: "ModuleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    CourseId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Price = table.Column<decimal>(type: "numeric(7,2)", precision: 7, scale: 2, nullable: false),
                    Category = table.Column<string>(type: "text", nullable: false),
                    PublisherId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.CourseId);
                    table.ForeignKey(
                        name: "FK_Courses_Publishers_PublisherId",
                        column: x => x.PublisherId,
                        principalTable: "Publishers",
                        principalColumn: "PublisherId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    QuestionId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Questioning = table.Column<string>(type: "text", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastUpdate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Category = table.Column<string>(type: "text", nullable: false),
                    LessonId = table.Column<int>(type: "integer", nullable: false),
                    StudentId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.QuestionId);
                    table.ForeignKey(
                        name: "FK_Questions_Lessons_LessonId",
                        column: x => x.LessonId,
                        principalTable: "Lessons",
                        principalColumn: "LessonId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Questions_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PublishersCourses",
                columns: table => new
                {
                    AuthorId = table.Column<int>(type: "integer", nullable: false),
                    CourseId = table.Column<int>(type: "integer", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PublishersCourses", x => new { x.AuthorId, x.CourseId });
                    table.ForeignKey(
                        name: "FK_PublishersCourses_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "AuthorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PublishersCourses_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Answers",
                columns: table => new
                {
                    AnswerId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Body = table.Column<string>(type: "text", nullable: false),
                    QuestionId = table.Column<int>(type: "integer", nullable: false),
                    AuthorId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Answers", x => x.AnswerId);
                    table.ForeignKey(
                        name: "FK_Answers_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "AuthorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Answers_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "QuestionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "AuthorId", "CPF", "Name" },
                values: new object[,]
                {
                    { 1, "23743614626", "Grace Hopper" },
                    { 2, "13047822638", "John Backus" },
                    { 3, "41275433375", "Bill Gates" },
                    { 4, "68999916405", "Jim Berners-Lee" },
                    { 5, "46786017673", "Linus Torvalds" }
                });

            migrationBuilder.InsertData(
                table: "Modules",
                column: "ModuleId",
                values: new object[]
                {
                    1,
                    2
                });

            migrationBuilder.InsertData(
                table: "Publishers",
                columns: new[] { "PublisherId", "CNPJ", "Name" },
                values: new object[,]
                {
                    { 1, "14698277000144", "Steven Spielberg Production Company" },
                    { 2, "12135618000148", "James Cameron Corporation" },
                    { 3, "64167199000120", "Quentin Tarantino Production" }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "StudentId", "Age", "CPF", "Name", "RegistrationDate" },
                values: new object[,]
                {
                    { 1, 21, "12345678980", "Steven Spielberg", new DateTime(2023, 7, 7, 15, 46, 40, 302, DateTimeKind.Utc).AddTicks(7856) },
                    { 2, 30, "09876543212", "Pedro Certezas", new DateTime(2023, 7, 7, 15, 46, 40, 302, DateTimeKind.Utc).AddTicks(7859) },
                    { 3, 21, "02036032907", "Casimiro Miguel", new DateTime(2023, 7, 7, 15, 46, 40, 302, DateTimeKind.Utc).AddTicks(7860) }
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "CourseId", "Category", "Description", "Price", "PublisherId", "Title" },
                values: new object[,]
                {
                    { 1, "Backend", "In this course, you'll learn how to build an API with ASP.NET Core that connects to a database via Entity Framework Core from scratch.", 97.00m, 1, "ASP.NET Core Web Api" },
                    { 2, "Backend", "In this course, Entity Framework Core 6 Fundamentals, you’ll learn to work with data in your .NET applications.", 197.00m, 1, "Entity Framework Fundamentals" },
                    { 3, "Operating Systems", "You've heard that Linux is the future of enterprise computing and you're looking for a way in.", 47.00m, 2, "Getting Started with Linux" }
                });

            migrationBuilder.InsertData(
                table: "Lessons",
                columns: new[] { "LessonId", "Description", "ModuleId", "Title" },
                values: new object[,]
                {
                    { 1, "aslkdnsadlaslkdnsadlaslkdnsadlaslkdnsadlaslkdnsadlaslkdnsadl", 1, "aslkdnsadl" },
                    { 2, "aslkdnsadlaslkdnakjdlkasjsadlaslkdnsadlaslkdnsadlaslkdnsadlaslkdnsadl", 2, "aslkdnsadlaslkdnsadl" },
                    { 3, "aslkdnsadlaslkdnakjdlkasjsadlaslkdnsadlaslkdnsadlaslkdnsadlaslkdnsadaslkdnsadlaslkdnsadlaslkdnsadlaslkdnsadlaslkdnsadlaslkdnsadlaslkdnsadlaslkdnsadlaslkdnsadlaslkdnsadlaslkdnsadlaslkdnsadlaslkdnsadlaslkdnsadlaslkdnsadlaslkdnsadlaslkdnsadlaslkdnsadlaslkdnsadlaslkdnsadlaslkdnsadlaslkdnsadlaslkdnsadlaslkdnsadlaslkdnsadlaslkdnsadll", 1, "aslkdl" }
                });

            migrationBuilder.InsertData(
                table: "PublishersCourses",
                columns: new[] { "AuthorId", "CourseId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 3 },
                    { 2, 1 },
                    { 2, 2 },
                    { 4, 1 },
                    { 5, 3 }
                });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "QuestionId", "Category", "CreationDate", "LastUpdate", "LessonId", "Questioning", "StudentId" },
                values: new object[,]
                {
                    { 1, "status-code", new DateTime(2023, 7, 7, 15, 46, 40, 302, DateTimeKind.Utc).AddTicks(7873), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "What status code should I return in the get method?", 1 },
                    { 2, "controller", new DateTime(2023, 7, 7, 15, 46, 40, 302, DateTimeKind.Utc).AddTicks(7875), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "What is the function of a controller?", 1 },
                    { 3, "controller", new DateTime(2023, 7, 7, 15, 46, 40, 302, DateTimeKind.Utc).AddTicks(7876), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Should I make a controller for each entity?", 2 },
                    { 4, "FluentValidation", new DateTime(2023, 7, 7, 15, 46, 40, 302, DateTimeKind.Utc).AddTicks(7877), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "How to set the precision of a decimal in FluentValidation?", 2 },
                    { 5, "FluentValidation", new DateTime(2023, 7, 7, 15, 46, 40, 302, DateTimeKind.Utc).AddTicks(7879), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "How to validate a text field to ensure it is not empty?", 3 },
                    { 6, "FluentValidation", new DateTime(2023, 7, 7, 15, 46, 40, 302, DateTimeKind.Utc).AddTicks(7880), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Como validar um campo de data para garantir que esteja em um intervalo específico?", 3 }
                });

            migrationBuilder.InsertData(
                table: "Answers",
                columns: new[] { "AnswerId", "AuthorId", "Body", "QuestionId" },
                values: new object[,]
                {
                    { 1, 1, "andsjkoflasdmasslfndsjklfnsdjkfnsdkjfbsdhfbshbfsdhfbsdhfbsdhfbs", 1 },
                    { 2, 2, "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", 1 },
                    { 3, 2, "bbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbb", 2 },
                    { 4, 1, "andsjkoflasdmasslfndsjklfnsdjkfnsdkjfbsdhfbshbfsdhfbsdhfbsdhfbs", 3 },
                    { 5, 1, "andsjkoflasdmasslfndsjklfnsdjkf", 3 },
                    { 6, 1, "alsdglçsdgs,lgsgslgsfgfslgfçgfçglfgkfgfgf", 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Answers_AuthorId",
                table: "Answers",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Answers_QuestionId",
                table: "Answers",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_PublisherId",
                table: "Courses",
                column: "PublisherId");

            migrationBuilder.CreateIndex(
                name: "IX_Lessons_ModuleId",
                table: "Lessons",
                column: "ModuleId");

            migrationBuilder.CreateIndex(
                name: "IX_PublishersCourses_CourseId",
                table: "PublishersCourses",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_LessonId",
                table: "Questions",
                column: "LessonId");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_StudentId",
                table: "Questions",
                column: "StudentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Answers");

            migrationBuilder.DropTable(
                name: "PublishersCourses");

            migrationBuilder.DropTable(
                name: "Questions");

            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Lessons");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Publishers");

            migrationBuilder.DropTable(
                name: "Modules");
        }
    }
}
