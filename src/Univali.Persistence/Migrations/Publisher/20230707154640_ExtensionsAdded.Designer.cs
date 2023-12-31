﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Univali.Api.DbContexts;

#nullable disable

namespace Univali.Api.Migrations.Publisher
{
    [DbContext(typeof(PublisherContext))]
    [Migration("20230707154640_ExtensionsAdded")]
    partial class ExtensionsAdded
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Univali.Api.Entities.Answer", b =>
                {
                    b.Property<int>("AnswerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("AnswerId"));

                    b.Property<int>("AuthorId")
                        .HasColumnType("integer");

                    b.Property<string>("Body")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("QuestionId")
                        .HasColumnType("integer");

                    b.HasKey("AnswerId");

                    b.HasIndex("AuthorId");

                    b.HasIndex("QuestionId");

                    b.ToTable("Answers");

                    b.HasData(
                        new
                        {
                            AnswerId = 1,
                            AuthorId = 1,
                            Body = "andsjkoflasdmasslfndsjklfnsdjkfnsdkjfbsdhfbshbfsdhfbsdhfbsdhfbs",
                            QuestionId = 1
                        },
                        new
                        {
                            AnswerId = 2,
                            AuthorId = 2,
                            Body = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa",
                            QuestionId = 1
                        },
                        new
                        {
                            AnswerId = 3,
                            AuthorId = 2,
                            Body = "bbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbb",
                            QuestionId = 2
                        },
                        new
                        {
                            AnswerId = 4,
                            AuthorId = 1,
                            Body = "andsjkoflasdmasslfndsjklfnsdjkfnsdkjfbsdhfbshbfsdhfbsdhfbsdhfbs",
                            QuestionId = 3
                        },
                        new
                        {
                            AnswerId = 5,
                            AuthorId = 1,
                            Body = "andsjkoflasdmasslfndsjklfnsdjkf",
                            QuestionId = 3
                        },
                        new
                        {
                            AnswerId = 6,
                            AuthorId = 1,
                            Body = "alsdglçsdgs,lgsgslgsfgfslgfçgfçglfgkfgfgf",
                            QuestionId = 3
                        });
                });

            modelBuilder.Entity("Univali.Api.Entities.Author", b =>
                {
                    b.Property<int>("AuthorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("AuthorId"));

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("character(11)")
                        .IsFixedLength();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("character varying(80)");

                    b.HasKey("AuthorId");

                    b.ToTable("Authors");

                    b.HasData(
                        new
                        {
                            AuthorId = 1,
                            CPF = "23743614626",
                            Name = "Grace Hopper"
                        },
                        new
                        {
                            AuthorId = 2,
                            CPF = "13047822638",
                            Name = "John Backus"
                        },
                        new
                        {
                            AuthorId = 3,
                            CPF = "41275433375",
                            Name = "Bill Gates"
                        },
                        new
                        {
                            AuthorId = 4,
                            CPF = "68999916405",
                            Name = "Jim Berners-Lee"
                        },
                        new
                        {
                            AuthorId = 5,
                            CPF = "46786017673",
                            Name = "Linus Torvalds"
                        });
                });

            modelBuilder.Entity("Univali.Api.Entities.AuthorCourse", b =>
                {
                    b.Property<int>("AuthorId")
                        .HasColumnType("integer");

                    b.Property<int>("CourseId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreatedOn")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("NOW()");

                    b.HasKey("AuthorId", "CourseId");

                    b.HasIndex("CourseId");

                    b.ToTable("PublishersCourses", (string)null);

                    b.HasData(
                        new
                        {
                            AuthorId = 1,
                            CourseId = 1,
                            CreatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            AuthorId = 1,
                            CourseId = 3,
                            CreatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            AuthorId = 2,
                            CourseId = 1,
                            CreatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            AuthorId = 2,
                            CourseId = 2,
                            CreatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            AuthorId = 4,
                            CourseId = 1,
                            CreatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            AuthorId = 5,
                            CourseId = 3,
                            CreatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("Univali.Api.Entities.Course", b =>
                {
                    b.Property<int>("CourseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("CourseId"));

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("Price")
                        .HasPrecision(7, 2)
                        .HasColumnType("numeric(7,2)");

                    b.Property<int>("PublisherId")
                        .HasColumnType("integer");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.HasKey("CourseId");

                    b.HasIndex("PublisherId");

                    b.ToTable("Courses");

                    b.HasData(
                        new
                        {
                            CourseId = 1,
                            Category = "Backend",
                            Description = "In this course, you'll learn how to build an API with ASP.NET Core that connects to a database via Entity Framework Core from scratch.",
                            Price = 97.00m,
                            PublisherId = 1,
                            Title = "ASP.NET Core Web Api"
                        },
                        new
                        {
                            CourseId = 2,
                            Category = "Backend",
                            Description = "In this course, Entity Framework Core 6 Fundamentals, you’ll learn to work with data in your .NET applications.",
                            Price = 197.00m,
                            PublisherId = 1,
                            Title = "Entity Framework Fundamentals"
                        },
                        new
                        {
                            CourseId = 3,
                            Category = "Operating Systems",
                            Description = "You've heard that Linux is the future of enterprise computing and you're looking for a way in.",
                            Price = 47.00m,
                            PublisherId = 2,
                            Title = "Getting Started with Linux"
                        });
                });

            modelBuilder.Entity("Univali.Api.Entities.Lesson", b =>
                {
                    b.Property<int>("LessonId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("LessonId"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("ModuleId")
                        .HasColumnType("integer");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("LessonId");

                    b.HasIndex("ModuleId");

                    b.ToTable("Lessons");

                    b.HasData(
                        new
                        {
                            LessonId = 1,
                            Description = "aslkdnsadlaslkdnsadlaslkdnsadlaslkdnsadlaslkdnsadlaslkdnsadl",
                            ModuleId = 1,
                            Title = "aslkdnsadl"
                        },
                        new
                        {
                            LessonId = 2,
                            Description = "aslkdnsadlaslkdnakjdlkasjsadlaslkdnsadlaslkdnsadlaslkdnsadlaslkdnsadl",
                            ModuleId = 2,
                            Title = "aslkdnsadlaslkdnsadl"
                        },
                        new
                        {
                            LessonId = 3,
                            Description = "aslkdnsadlaslkdnakjdlkasjsadlaslkdnsadlaslkdnsadlaslkdnsadlaslkdnsadaslkdnsadlaslkdnsadlaslkdnsadlaslkdnsadlaslkdnsadlaslkdnsadlaslkdnsadlaslkdnsadlaslkdnsadlaslkdnsadlaslkdnsadlaslkdnsadlaslkdnsadlaslkdnsadlaslkdnsadlaslkdnsadlaslkdnsadlaslkdnsadlaslkdnsadlaslkdnsadlaslkdnsadlaslkdnsadlaslkdnsadlaslkdnsadlaslkdnsadlaslkdnsadll",
                            ModuleId = 1,
                            Title = "aslkdl"
                        });
                });

            modelBuilder.Entity("Univali.Api.Entities.Module", b =>
                {
                    b.Property<int>("ModuleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ModuleId"));

                    b.HasKey("ModuleId");

                    b.ToTable("Modules");

                    b.HasData(
                        new
                        {
                            ModuleId = 1
                        },
                        new
                        {
                            ModuleId = 2
                        });
                });

            modelBuilder.Entity("Univali.Api.Entities.Publisher", b =>
                {
                    b.Property<int>("PublisherId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("PublisherId"));

                    b.Property<string>("CNPJ")
                        .IsRequired()
                        .HasMaxLength(14)
                        .HasColumnType("character(14)")
                        .IsFixedLength();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("character varying(80)");

                    b.HasKey("PublisherId");

                    b.ToTable("Publishers");

                    b.HasData(
                        new
                        {
                            PublisherId = 1,
                            CNPJ = "14698277000144",
                            Name = "Steven Spielberg Production Company"
                        },
                        new
                        {
                            PublisherId = 2,
                            CNPJ = "12135618000148",
                            Name = "James Cameron Corporation"
                        },
                        new
                        {
                            PublisherId = 3,
                            CNPJ = "64167199000120",
                            Name = "Quentin Tarantino Production"
                        });
                });

            modelBuilder.Entity("Univali.Api.Entities.Question", b =>
                {
                    b.Property<int>("QuestionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("QuestionId"));

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("LastUpdate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("LessonId")
                        .HasColumnType("integer");

                    b.Property<string>("Questioning")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("StudentId")
                        .HasColumnType("integer");

                    b.HasKey("QuestionId");

                    b.HasIndex("LessonId");

                    b.HasIndex("StudentId");

                    b.ToTable("Questions");

                    b.HasData(
                        new
                        {
                            QuestionId = 1,
                            Category = "status-code",
                            CreationDate = new DateTime(2023, 7, 7, 15, 46, 40, 302, DateTimeKind.Utc).AddTicks(7873),
                            LastUpdate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LessonId = 1,
                            Questioning = "What status code should I return in the get method?",
                            StudentId = 1
                        },
                        new
                        {
                            QuestionId = 2,
                            Category = "controller",
                            CreationDate = new DateTime(2023, 7, 7, 15, 46, 40, 302, DateTimeKind.Utc).AddTicks(7875),
                            LastUpdate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LessonId = 2,
                            Questioning = "What is the function of a controller?",
                            StudentId = 1
                        },
                        new
                        {
                            QuestionId = 3,
                            Category = "controller",
                            CreationDate = new DateTime(2023, 7, 7, 15, 46, 40, 302, DateTimeKind.Utc).AddTicks(7876),
                            LastUpdate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LessonId = 2,
                            Questioning = "Should I make a controller for each entity?",
                            StudentId = 2
                        },
                        new
                        {
                            QuestionId = 4,
                            Category = "FluentValidation",
                            CreationDate = new DateTime(2023, 7, 7, 15, 46, 40, 302, DateTimeKind.Utc).AddTicks(7877),
                            LastUpdate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LessonId = 3,
                            Questioning = "How to set the precision of a decimal in FluentValidation?",
                            StudentId = 2
                        },
                        new
                        {
                            QuestionId = 5,
                            Category = "FluentValidation",
                            CreationDate = new DateTime(2023, 7, 7, 15, 46, 40, 302, DateTimeKind.Utc).AddTicks(7879),
                            LastUpdate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LessonId = 3,
                            Questioning = "How to validate a text field to ensure it is not empty?",
                            StudentId = 3
                        },
                        new
                        {
                            QuestionId = 6,
                            Category = "FluentValidation",
                            CreationDate = new DateTime(2023, 7, 7, 15, 46, 40, 302, DateTimeKind.Utc).AddTicks(7880),
                            LastUpdate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LessonId = 3,
                            Questioning = "Como validar um campo de data para garantir que esteja em um intervalo específico?",
                            StudentId = 3
                        });
                });

            modelBuilder.Entity("Univali.Api.Entities.Student", b =>
                {
                    b.Property<int>("StudentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("StudentId"));

                    b.Property<int>("Age")
                        .HasMaxLength(3)
                        .HasColumnType("integer")
                        .IsFixedLength();

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("character(11)")
                        .IsFixedLength();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("character varying(80)");

                    b.Property<DateTime>("RegistrationDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("StudentId");

                    b.ToTable("Students");

                    b.HasData(
                        new
                        {
                            StudentId = 1,
                            Age = 21,
                            CPF = "12345678980",
                            Name = "Steven Spielberg",
                            RegistrationDate = new DateTime(2023, 7, 7, 15, 46, 40, 302, DateTimeKind.Utc).AddTicks(7856)
                        },
                        new
                        {
                            StudentId = 2,
                            Age = 30,
                            CPF = "09876543212",
                            Name = "Pedro Certezas",
                            RegistrationDate = new DateTime(2023, 7, 7, 15, 46, 40, 302, DateTimeKind.Utc).AddTicks(7859)
                        },
                        new
                        {
                            StudentId = 3,
                            Age = 21,
                            CPF = "02036032907",
                            Name = "Casimiro Miguel",
                            RegistrationDate = new DateTime(2023, 7, 7, 15, 46, 40, 302, DateTimeKind.Utc).AddTicks(7860)
                        });
                });

            modelBuilder.Entity("Univali.Api.Entities.Answer", b =>
                {
                    b.HasOne("Univali.Api.Entities.Author", "Author")
                        .WithMany("Answers")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Univali.Api.Entities.Question", "Question")
                        .WithMany("Answers")
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");

                    b.Navigation("Question");
                });

            modelBuilder.Entity("Univali.Api.Entities.AuthorCourse", b =>
                {
                    b.HasOne("Univali.Api.Entities.Author", null)
                        .WithMany()
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Univali.Api.Entities.Course", null)
                        .WithMany()
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Univali.Api.Entities.Course", b =>
                {
                    b.HasOne("Univali.Api.Entities.Publisher", "Publisher")
                        .WithMany("Courses")
                        .HasForeignKey("PublisherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Publisher");
                });

            modelBuilder.Entity("Univali.Api.Entities.Lesson", b =>
                {
                    b.HasOne("Univali.Api.Entities.Module", "Module")
                        .WithMany("Lessons")
                        .HasForeignKey("ModuleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Module");
                });

            modelBuilder.Entity("Univali.Api.Entities.Question", b =>
                {
                    b.HasOne("Univali.Api.Entities.Lesson", "Lesson")
                        .WithMany("Questions")
                        .HasForeignKey("LessonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Univali.Api.Entities.Student", "Student")
                        .WithMany("Questions")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Lesson");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("Univali.Api.Entities.Author", b =>
                {
                    b.Navigation("Answers");
                });

            modelBuilder.Entity("Univali.Api.Entities.Lesson", b =>
                {
                    b.Navigation("Questions");
                });

            modelBuilder.Entity("Univali.Api.Entities.Module", b =>
                {
                    b.Navigation("Lessons");
                });

            modelBuilder.Entity("Univali.Api.Entities.Publisher", b =>
                {
                    b.Navigation("Courses");
                });

            modelBuilder.Entity("Univali.Api.Entities.Question", b =>
                {
                    b.Navigation("Answers");
                });

            modelBuilder.Entity("Univali.Api.Entities.Student", b =>
                {
                    b.Navigation("Questions");
                });
#pragma warning restore 612, 618
        }
    }
}
