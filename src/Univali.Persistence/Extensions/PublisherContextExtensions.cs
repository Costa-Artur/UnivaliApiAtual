using Microsoft.EntityFrameworkCore;
using Univali.Api.Entities;

namespace Univali.Api.Extensions;

internal static class PublisherContextExtensions
{
    public static void PublisherInitFluentApi(this ModelBuilder modelBuilder)
    {
        var publisher = modelBuilder.Entity<Publisher>();

        publisher.HasMany(a => a.Courses)
            .WithOne(c => c.Publisher)
            .HasForeignKey(c => c.PublisherId);

        publisher.Property(p => p.Name)
            .HasMaxLength(80)
            .IsRequired();

        publisher.Property(p => p.CNPJ)
            .HasMaxLength(14)
            .IsFixedLength();
    }

    public static void AuthorInitFluentApi(this ModelBuilder modelBuilder)
    {
        var author = modelBuilder.Entity<Author>();

        author.HasMany(a => a.Courses)
            .WithMany(c => c.Authors)
            .UsingEntity<AuthorCourse>(
                ac => ac.ToTable("PublishersCourses")
               .Property(ac => ac.CreatedOn).HasDefaultValueSql("NOW()")
            );
        
        author.HasMany(au => au.Answers)
            .WithOne(an => an.Author)
            .HasForeignKey(an => an.AuthorId);
            
        author.Property(a => a.Name)
            .HasMaxLength(80)
            .IsRequired();

        author.Property(a => a.CPF)
            .HasMaxLength(11)
            .IsFixedLength();
    }

    public static void CourseInitFluentApi(this ModelBuilder modelBuilder)
    {
        var course = modelBuilder.Entity<Course>();

        course.Property(c => c.Title)
            .HasMaxLength(100)
            .IsRequired();

        course.Property(c => c.Price)
            .HasPrecision(7,2)
            .IsRequired();

        course.Property(c => c.Description)
            .IsRequired();
    }

    public static void ModuleInitFluentApi(this ModelBuilder modelBuilder)
    {
        var module = modelBuilder.Entity<Module>();

        module.HasMany(m => m.Lessons)
            .WithOne(c => c.Module)
            .HasForeignKey(c => c.ModuleId);
    }

    public static void LessonInitFluentApi(this ModelBuilder modelBuilder)
    {
        var lesson = modelBuilder.Entity<Lesson>();

        lesson.HasMany(c => c.Questions)
            .WithOne(q => q.Lesson)
            .HasForeignKey(q => q.LessonId);
    }

    public static void StudentInitFluentApi(this ModelBuilder modelBuilder)
    {
        var student = modelBuilder.Entity<Student>();

        student.HasMany(s => s.Questions)
            .WithOne(q => q.Student)
            .HasForeignKey(q => q.StudentId);
        
        student.Property(p => p.Name)
            .HasMaxLength(80)
            .IsRequired();

        student.Property(p => p.CPF)
            .HasMaxLength(11)
            .IsFixedLength();
        
        student.Property(p => p.Age)
            .HasMaxLength(3)
            .IsFixedLength();
    }

    public static void QuestionInitFluentApi(this ModelBuilder modelBuilder)
    {
        var question = modelBuilder.Entity<Question>();

        question.HasMany(q => q.Answers)
            .WithOne(an => an.Question)
            .HasForeignKey(an => an.QuestionId);

        question.Property(q => q.Questioning)
            .IsRequired();

        question.Property(q => q.CreationDate)
            .IsRequired();
        
        question.Property(q => q.Category)
            .IsRequired();
        
        question.Property(q => q.LessonId)
            .IsRequired();
        
        question.Property(q => q.StudentId)
            .IsRequired();
    }

    public static void AnswerInitFluentApi(this ModelBuilder modelBuilder)
    {
        var answer = modelBuilder.Entity<Answer>();

        answer.Property(an => an.QuestionId)
            .IsRequired();
        
        answer.Property(an => an.Body)
            .IsRequired();
        
        answer.Property(an => an.QuestionId)
            .IsRequired();
        
        answer.Property(an => an.AuthorId)
            .IsRequired();
    }



    public static void PublisherContextSeedData(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Publisher>().HasData(
            new Publisher
            {
                PublisherId = 1,
                Name = "Steven Spielberg Production Company",
                CNPJ = "14698277000144",
            },
            new Publisher
            {
                PublisherId = 2,
                Name = "James Cameron Corporation",
                CNPJ = "12135618000148",
            },
            new Publisher
            {
                PublisherId = 3,
                Name = "Quentin Tarantino Production",
                CNPJ = "64167199000120",
            }
        );

        modelBuilder.Entity<Author>().HasData(
            new Author
            {
                AuthorId = 1,
                Name = "Grace Hopper",
                CPF = "23743614626",
            },
            new Author
            {
                AuthorId = 2,
                Name = "John Backus",
                CPF = "13047822638",
            },
            new Author
            {
                AuthorId = 3,
                Name = "Bill Gates",
                CPF = "41275433375",
            },
            new Author
            {
                AuthorId = 4,
                Name = "Jim Berners-Lee",
                CPF = "68999916405",
            },
            new Author
            {
                AuthorId = 5,
                Name = "Linus Torvalds",
                CPF = "46786017673",
            }
        );

        modelBuilder.Entity<Course>().HasData(
            new Course
            {
                CourseId = 1,
                Title = "ASP.NET Core Web Api",
                Price = 97.00m,
                Description = "In this course, you'll learn how to build an API with ASP.NET Core that connects to a database via Entity Framework Core from scratch.",
                Category = "Backend",
                PublisherId = 1
            },
            new Course
            {
                CourseId = 2,
                Title = "Entity Framework Fundamentals",
                Price = 197.00m,
                Description = "In this course, Entity Framework Core 6 Fundamentals, you’ll learn to work with data in your .NET applications.",
                Category = "Backend",
                PublisherId = 1
            },
            new Course
            {
                CourseId = 3,
                Title = "Getting Started with Linux",
                Price = 47.00m,
                Description = "You've heard that Linux is the future of enterprise computing and you're looking for a way in.",
                Category = "Operating Systems",
                PublisherId = 2
            },
            new Course
            {
                CourseId = 4,
                Title = "Getting Started with Windows",
                Price = 47.00m,
                Description = "You've heard that Windows is the future of enterprise computing and you're looking for a way in.",
                Category = "Operating Systems",
                PublisherId = 2
            },
            new Course
            {
                CourseId = 5,
                Title = "Javascript Fundamentals",
                Price = 197.00m,
                Description = "In this course, Javascript Fundamentals, you’ll learn to work with data in your .NET applications.",
                Category = "Backend",
                PublisherId = 1
            },
            new Course
            {
                CourseId = 6,
                Title = "FrontEnd Fundamentals",
                Price = 197.00m,
                Description = "In this course, FrontEnd Fundamentals, you’ll learn to work with data in your .NET applications.",
                Category = "Backend",
                PublisherId = 1
            },
            new Course
            {
                CourseId = 7,
                Title = "C# Fundamentals",
                Price = 197.00m,
                Description = "In this course, C# Fundamentals, you’ll learn to work with data in your .NET applications.",
                Category = "Backend",
                PublisherId = 1
            }
        );

        modelBuilder.Entity<AuthorCourse>().HasData(
            new AuthorCourse { AuthorId = 1, CourseId = 1 },
            new AuthorCourse { AuthorId = 1, CourseId = 3 },
            new AuthorCourse { AuthorId = 2, CourseId = 1 },
            new AuthorCourse { AuthorId = 2, CourseId = 2 },
            new AuthorCourse { AuthorId = 4, CourseId = 1 },
            new AuthorCourse { AuthorId = 5, CourseId = 3 }
        );

        modelBuilder.Entity<Module>().HasData(
            new Module
            {
                ModuleId = 1,
            },
            new Module
            {
                ModuleId = 2,
            }
        );

        modelBuilder.Entity<Lesson>().HasData(
            new Lesson
            {
                LessonId = 1,
                Title = "aslkdnsadl",
                Description = "aslkdnsadlaslkdnsadlaslkdnsadlaslkdnsadlaslkdnsadlaslkdnsadl",
                ModuleId = 1
            },
            new Lesson
            {
                LessonId = 2,
                Title = "aslkdnsadlaslkdnsadl",
                Description = "aslkdnsadlaslkdnakjdlkasjsadlaslkdnsadlaslkdnsadlaslkdnsadlaslkdnsadl",
                ModuleId = 2
            },
            new Lesson
            {
                LessonId = 3,
                Title = "aslkdl",
                Description = "aslkdnsadlaslkdnakjdlkasjsadlaslkdnsadlaslkdnsadlaslkdnsadlaslkdnsadaslkdnsadlaslkdnsadlaslkdnsadlaslkdnsadlaslkdnsadlaslkdnsadlaslkdnsadlaslkdnsadlaslkdnsadlaslkdnsadlaslkdnsadlaslkdnsadlaslkdnsadlaslkdnsadlaslkdnsadlaslkdnsadlaslkdnsadlaslkdnsadlaslkdnsadlaslkdnsadlaslkdnsadlaslkdnsadlaslkdnsadlaslkdnsadlaslkdnsadlaslkdnsadll",
                ModuleId = 1
            }
        );

        modelBuilder.Entity<Student>().HasData(
            new Student
            {
                StudentId = 1,
                Name = "Steven Spielberg",
                CPF = "12345678980",
                Age = 21,
                RegistrationDate = DateTime.UtcNow
            },
            new Student
            {
                StudentId = 2,
                Name = "Pedro Certezas",
                CPF = "09876543212",
                Age = 30,
                RegistrationDate = DateTime.UtcNow
            },
            new Student
            {
                StudentId = 3,
                Name = "Casimiro Miguel",
                CPF = "02036032907",
                Age = 21,
                RegistrationDate = DateTime.UtcNow
            }
        );

        modelBuilder.Entity<Question>().HasData(
            new Question
            {
                QuestionId = 1,
                Questioning = "What status code should I return in the get method?",
                Category = "status-code",
                CreationDate = DateTime.UtcNow,
                LessonId = 1,
                StudentId = 1
            },
            new Question
            {
                QuestionId = 2,
                Questioning = "What is the function of a controller?",
                Category = "controller",
                CreationDate = DateTime.UtcNow,
                LessonId = 2,
                StudentId = 1
            },
            new Question
            {
                QuestionId = 3,
                Questioning = "Should I make a controller for each entity?",
                Category = "controller",
                CreationDate = DateTime.UtcNow,
                LessonId = 2,
                StudentId = 2
            },
            new Question
            {
                QuestionId = 4,
                Questioning = "How to set the precision of a decimal in FluentValidation?",
                Category = "FluentValidation",
                CreationDate = DateTime.UtcNow,
                LessonId = 3,
                StudentId = 2
            },
            new Question
            {
                QuestionId = 5,
                Questioning = "How to validate a text field to ensure it is not empty?",
                Category = "FluentValidation",
                CreationDate = DateTime.UtcNow,
                LessonId = 3,
                StudentId = 3
            },
            new Question
            {
                QuestionId = 6,
                Questioning = "Como validar um campo de data para garantir que esteja em um intervalo específico?",
                Category = "FluentValidation",
                CreationDate = DateTime.UtcNow,
                LessonId = 3,
                StudentId = 3
            }
        );

        modelBuilder.Entity<Answer>().HasData(
            new Answer {
                AnswerId = 1,
                Body = "andsjkoflasdmasslfndsjklfnsdjkfnsdkjfbsdhfbshbfsdhfbsdhfbsdhfbs",
                QuestionId = 1,
                AuthorId = 1,
            },
            new Answer {
                AnswerId = 2,
                Body = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa",
                QuestionId = 1,
                AuthorId = 2,
            },
            new Answer {
                AnswerId = 3,
                Body = "bbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbb",
                QuestionId = 2,
                AuthorId = 2,
            },
            new Answer {
                AnswerId = 4,
                Body = "andsjkoflasdmasslfndsjklfnsdjkfnsdkjfbsdhfbshbfsdhfbsdhfbsdhfbs",
                QuestionId = 3,
                AuthorId = 1,
            },
            new Answer {
                AnswerId = 5,
                Body = "andsjkoflasdmasslfndsjklfnsdjkf",
                QuestionId = 3,
                AuthorId = 1,
            },
            new Answer {
                AnswerId = 6,
                Body = "alsdglçsdgs,lgsgslgsfgfslgfçgfçglfgkfgfgf",
                QuestionId = 3,
                AuthorId = 1,
            }
        );
    }
}